//#include <mpi.h>
//#include <iostream>
//
//using namespace std;
//
//int main(int argc, char** argv) {
//
//	int rank, size;
//	MPI_File fh;
//	const char* fileName = "test-c.dat";
//
//	MPI_Init(&argc, &argv);
//
//	MPI_Comm_rank(MPI_COMM_WORLD, &rank);
//	MPI_Comm_size(MPI_COMM_WORLD, &size);
//
//	int myWriteData = rank;
//	printf("My rank is %d, and my write data is %d\n", rank, myWriteData);
//
//	// Writing data
//
//	MPI_File_open(MPI_COMM_WORLD, fileName, MPI_MODE_CREATE | MPI_MODE_WRONLY, MPI_INFO_NULL, &fh);
//
//	MPI_File_seek(fh, rank * sizeof(MPI_INT), MPI_SEEK_SET);
//
//	MPI_File_write(fh, &myWriteData, 1, MPI_INT, MPI_STATUS_IGNORE);
//
//	MPI_File_close(&fh);
//
//	// Reading data
//	MPI_Barrier(MPI_COMM_WORLD);
//
//	int myReadData = -1;
//
//	MPI_File_open(MPI_COMM_WORLD, fileName,  MPI_MODE_RDONLY, MPI_INFO_NULL, &fh);
//
//	if (rank != 0)
//		MPI_File_seek(fh, (rank - 1) * sizeof(MPI_INT), MPI_SEEK_SET);
//	else 
//		MPI_File_seek(fh, (size - 1) * sizeof(MPI_INT), MPI_SEEK_SET);
//
//	MPI_File_read(fh, &myReadData, 1, MPI_INT, MPI_STATUS_IGNORE);
//
//	MPI_File_close(&fh);
//
//	printf("My rank is %d, my write data is %d, and my read data is %d\n", rank, myWriteData, myReadData);
//
//	MPI_Finalize();
//}