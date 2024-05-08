import struct


# def read_dat_file(file_path):
#     try:
#         with open(file_path, "rb") as file:
#             chars = []
#             while True:
#                 data = file.read(1)  # Assuming each char is 1 byte (8 bits)
#                 if not data:
#                     break
#                 char = struct.unpack("<i", data)[0]  # Assuming little-endian format
#                 chars.append(char)
#         return chars
#     except FileNotFoundError:
#         print(f"Error: File '{file_path}' not found.")
#         return None
#     except Exception as e:
#         print(f"An error occurred: {str(e)}")
#         return None


# def display_integers(integers):
#     if integers:
#         print("Integers in the file:")
#         for num in integers:
#             print(num)
#     else:
#         print("No integers to display.")


def print_characters_in_dat(file_path):
    try:
        with open(file_path, "rb") as file:
            characters = file.read().decode("utf-8")
            print("Characters in the file:")
            print(characters)
    except FileNotFoundError:
        print(f"Error: File '{file_path}' not found.")
    except Exception as e:
        print(f"An error occurred: {str(e)}")


if __name__ == "__main__":
    file_path = "C:\\Users\\masac\\OneDrive\\Desktop\\Masa\\Faks\\Distributed Systems\\Laboratories\\MPI\\x64\\Debug\\file2.dat"
    # integers = read_dat_file(file_path)
    # display_integers(integers)
    print_characters_in_dat(file_path)
