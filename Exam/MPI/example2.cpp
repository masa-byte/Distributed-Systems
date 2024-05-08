#include <mpi.h>
#include <iostream>
#define FILESIZE 120

using namespace std;


int main(int argc, char** argv) {

	int rank, size;
	MPI_File fh;
	const char* fileName = "test-c.dat";

	MPI_Init(&argc, &argv);

	MPI_Comm_rank(MPI_COMM_WORLD, &rank);
	MPI_Comm_size(MPI_COMM_WORLD, &size);

	// We have N processes and each will read the same number of bytes

	int bytesToRead = FILESIZE / size;
	int integersToRead = bytesToRead / sizeof(MPI_INT);
	int* myIntegers = new int(integersToRead);

	if (rank == 0)
		printf("There is %d of us so each one will read %d bytes -> %d integers\n", size, bytesToRead, integersToRead);

	MPI_Barrier(MPI_COMM_WORLD);

	MPI_File_open(MPI_COMM_WORLD, fileName, MPI_MODE_RDONLY, MPI_INFO_NULL, &fh);

	MPI_Datatype newType;

	MPI_Type_vector(1, 2, 6, MPI_INT, &newType);
	MPI_Type_commit(&newType);

	MPI_File_set_view(fh, rank * integersToRead * sizeof(MPI_INT), MPI_INT, newType, "native", MPI_INFO_NULL);

	MPI_File_read(fh, myIntegers, integersToRead, MPI_INT, MPI_STATUS_IGNORE);

	MPI_File_close(&fh);

	for (int i = 0; i < integersToRead; i++) {
		printf("My rank is %d, and my write data on index %d is %d\n", rank, i, myIntegers[i]);
	}

	MPI_Finalize();
}