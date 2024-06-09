#include <mpi.h>
#include <iostream>
#define k 6

int main(int argc, char** argv)
{
	const char* filename = "junski2023.dat";
	int rank, size;
	MPI_Init(&argc, &argv);
	MPI_Comm_size(MPI_COMM_WORLD, &size);
	MPI_Comm_rank(MPI_COMM_WORLD, &rank);

	MPI_File file;
	int numbersToWrite[k];
	int numbersToRead[k];
	int* sanityCheck = new int[k * size];

	for (int i = 0; i < k; i++)
	{
		numbersToWrite[i] = rank * k + i;
	}

	MPI_File_open(MPI_COMM_WORLD, filename, MPI_MODE_CREATE | MPI_MODE_WRONLY, MPI_INFO_NULL, &file);
	MPI_File_seek(file, k * rank * sizeof(int), MPI_SEEK_SET);
	MPI_File_write(file, numbersToWrite, k, MPI_INT, MPI_STATUS_IGNORE);

	MPI_File_close(&file);

	MPI_File_open(MPI_COMM_WORLD, filename, MPI_MODE_RDONLY, MPI_INFO_NULL, &file);
	MPI_File_read_at(file, k * rank * sizeof(int), numbersToRead, k, MPI_INT, MPI_STATUS_IGNORE);

	for (int i = 0; i < k; i++)
	{
		printf("My rank is %d and I am printing %d\n", rank, numbersToRead[i]);
	}

	MPI_File_close(&file);

	MPI_Datatype vector;
	int count = size;
	int blocklen = k / size;
	int stride = size * blocklen;
	MPI_Type_vector(size, blocklen, stride, MPI_INT, &vector);
	MPI_Type_commit(&vector);

	MPI_File_open(MPI_COMM_WORLD, filename, MPI_MODE_WRONLY, MPI_INFO_NULL, &file);

	MPI_File_set_view(file, rank * blocklen * sizeof(int), MPI_INT, vector, "native", MPI_INFO_NULL);

	MPI_File_write_all(file, numbersToRead, k, MPI_INT, MPI_STATUS_IGNORE);

	MPI_File_close(&file);

	MPI_File_open(MPI_COMM_WORLD, filename, MPI_MODE_RDONLY, MPI_INFO_NULL, &file);
	MPI_File_read_all(file, sanityCheck, k * size, MPI_INT, MPI_STATUSES_IGNORE);

	MPI_File_close(&file);

	if (rank == 0)
	{
		for (int i = 0; i < k * size; i++)
		{
			printf("%d\n", sanityCheck[i]);
		}
	}

	MPI_Finalize();
}