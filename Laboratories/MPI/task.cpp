//#include <mpi.h>
//#include <iostream>
//
//#define p 4
//#define numInts 10
//
//using namespace std;
//
//
//int main(int argc, char** argv) {
//
//	int rank, size;
//	int myInts[numInts];
//
//	MPI_File fh;
//	const char* file1 = "task-c.dat";
//	const char* file2 = "rr-c.dat";
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
//	for (int i = 0; i < numInts; i++)
//	{
//		myInts[i] = rank * numInts + i;
//	}
//	MPI_File_open(MPI_COMM_WORLD, file1, MPI_MODE_CREATE | MPI_MODE_WRONLY, MPI_INFO_NULL, &fh);
//
//	MPI_File_seek(fh, rank * numInts * sizeof(int), MPI_SEEK_SET);
//	MPI_File_write(fh, myInts, numInts, MPI_INT, MPI_STATUSES_IGNORE);
//
//	MPI_File_close(&fh);
//
//	// part 2
//	MPI_File_open(MPI_COMM_WORLD, file1, MPI_MODE_RDONLY, MPI_INFO_NULL, &fh);
//	MPI_File_read_at(fh, rank * numInts * sizeof(int), myInts, numInts, MPI_INT, MPI_STATUSES_IGNORE);
//
//	for (int i = 0; i < numInts; i++)
//	{
//		printf("My rank is %d and I read %d\n", rank, myInts[i]);
//	}
//
//	MPI_File_close(&fh);
//
//	// part 3
//	MPI_File_open(MPI_COMM_WORLD, file2, MPI_MODE_CREATE | MPI_MODE_WRONLY, MPI_INFO_NULL, &fh);
//
//	MPI_Datatype rr;
//	int blocklen = 2;
//	int count = numInts / blocklen;
//	MPI_Type_vector(count, blocklen, p * blocklen, MPI_INT, &rr);
//	MPI_Type_commit(&rr);
//
//	MPI_File_set_view(fh, rank * blocklen * sizeof(int), MPI_INT, rr, "native", MPI_INFO_NULL);
//
//	MPI_File_write_all(fh, myInts, numInts, MPI_INT, MPI_STATUSES_IGNORE);
//
//	MPI_File_close(&fh);
//
//	// sanity check
//	MPI_File_open(MPI_COMM_WORLD, file2, MPI_MODE_RDONLY, MPI_INFO_NULL, &fh);
//	MPI_File_read_at(fh, rank * numInts * sizeof(int), myInts, numInts, MPI_INT, MPI_STATUSES_IGNORE);
//
//	for (int i = 0; i < numInts; i++)
//	{
//		printf("My rank is %d and I read %d\n", rank, myInts[i]);
//	}
//
//	MPI_Barrier(MPI_COMM_WORLD);
//	MPI_File_seek(fh, 0, MPI_SEEK_SET);
//
//	MPI_File_set_view(fh, rank * blocklen * sizeof(int), MPI_INT, rr, "native", MPI_INFO_NULL);
//	MPI_File_read_all(fh, myInts, numInts, MPI_INT, MPI_STATUSES_IGNORE);
//
//	for (int i = 0; i < numInts; i++)
//	{
//		printf("My rank is %d and I read %d\n", rank, myInts[i]);
//	}
//
//	MPI_File_close(&fh);
//
//	MPI_Finalize();
//}