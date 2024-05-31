//#include <mpi.h>
//#include <iostream>
//
//#define p 4
//#define n 4
//
//using namespace std;
//
//
//int main(int argc, char** argv) {
//
//	int rank, size;
//	char writeText[n];
//	char readText[n];
//
//	MPI_File fh;
//	const char* file1 = "file1.dat";
//	const char* file2 = "file2.dat";
//
//	MPI_Init(&argc, &argv);
//
//	MPI_Comm_rank(MPI_COMM_WORLD, &rank);
//	MPI_Comm_size(MPI_COMM_WORLD, &size);
//
//	if (p != size)
//	{
//		if (rank == 0)
//			printf("Number of processes must be %d", p);
//		MPI_Finalize();
//		exit(-1);
//	}
//
//	// part 1
//	for (int i = 0; i < n; i++)
//	{
//		writeText[i] = 'a' + rank;
//	}
//
//	MPI_File_open(MPI_COMM_WORLD, file1, MPI_MODE_CREATE | MPI_MODE_WRONLY, MPI_INFO_NULL, &fh);
//
//	MPI_File_seek(fh, (size - 1 - rank) * n * sizeof(char), MPI_SEEK_SET);
//	MPI_File_write(fh, writeText, n, MPI_CHAR, MPI_STATUSES_IGNORE);
//
//	MPI_File_close(&fh);
//
//	// part 2
//	MPI_File_open(MPI_COMM_WORLD, file1, MPI_MODE_RDONLY, MPI_INFO_NULL, &fh);
//	MPI_File_read_shared(fh, readText, n, MPI_CHAR, MPI_STATUS_IGNORE);
//
//	for (int i = 0; i < n; i++)
//	{
//		printf("My rank is %d and I read %c\n", rank, readText[i]);
//	}
//
//	MPI_File_close(&fh);
//
//	// part 3
//	MPI_File_open(MPI_COMM_WORLD, file2, MPI_MODE_CREATE | MPI_MODE_WRONLY, MPI_INFO_NULL, &fh);
//
//	MPI_Datatype column;
//	MPI_Type_vector(n, 1, n, MPI_CHAR, &column);
//	MPI_Type_commit(&column);
//	MPI_File_set_view(fh, rank * sizeof(char), MPI_CHAR, column, "native", MPI_INFO_NULL);
//	MPI_File_write_all(fh, readText, n, MPI_CHAR, MPI_STATUSES_IGNORE);
//
//	MPI_File_close(&fh);
//
//	MPI_Finalize();
//}