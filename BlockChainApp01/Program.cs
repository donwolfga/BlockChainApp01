using System;


namespace BlockChainApp01
{
	//***************************************************************************************************************************
	//*
	//*		Name:			BlockChainApp01
	//*		Author:			Don Wolf
	//*		Date:			5/2018
	//*
	//*		Description:	This program creates the simplest blockchain. 
	//*						It demonstrates the use and the value of the cryptographic SHA256 hash to tie all the blocks together,
	//*						creating an immutable blockchain.
	//*						It's the simplest blockchain because:
	//*							1. It's in-memory only. Nothing is preserved after it runs.
	//*							2. It creates a fixed number of blocks.
	//*							3. The data portion of the blocks is "dummy data" only. No transactions are captured or stored.
	//*							4. It runs on a single computer. There's no distributed aspect to it.
	//*
	//*		Revisions:
	//*						6/22/2018 Added flower box comment and committed
	//****************************************************************************************************************************
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("BlockChainCreator version 1.0");
			Console.WriteLine("Push button to initiate blockchain creation");
			Console.ReadKey();
			
			//Constant to set the number of blocks in our blockchain:
			const int NumOfBlocks = 20;

			//Create an array to store the (NumOfBlocks) blocks:
			Console.WriteLine("Creating a blockchain of " + NumOfBlocks + " blocks");
			Block[] Blockchain = new Block[NumOfBlocks];

			//Initialize/populate the blockchain array with block objects:
			for (int i = 0; i < NumOfBlocks; i++)
			{
				Blockchain[i] = new Block();
			}

			//Load the Genesis block:
			Console.WriteLine("Initiating blockchain / creating Genesis block");
			Blockchain[0].CreateGenesisBlock();
			Blockchain[0].HashAppendedFields();
			Blockchain[0].HashThisBlock = ByteArrayToString(Blockchain[0].ByteArrayHash);

			Console.WriteLine("Genesis block created with the following:");
			Console.WriteLine("Genesis block index = " + Blockchain[0].Index);
			Console.WriteLine("Genesis block previousHash = " + Blockchain[0].HashPreviousBlock);
			Console.WriteLine("Genesis block timestamp = " + Blockchain[0].Timestamp);
			Console.WriteLine("Genesis block data = " + Blockchain[0].Data);
			Console.WriteLine("Genesis block hash = " + Blockchain[0].HashThisBlock + " (hash string length = " + Blockchain[0].HashThisBlock.Length + ")");
			
			Console.ReadKey();

			//Load all other blocks:
			for (int i = 1; i < NumOfBlocks; i++)
			{

				Blockchain[i].Index = i;
				Blockchain[i].Timestamp = DateTime.Now;
				Blockchain[i].Data = "We don't have any real data, so how about the cow jumped over the moon";
				Blockchain[i].HashPreviousBlock = Blockchain[i - 1].HashThisBlock;
				Blockchain[i].HashAppendedFields();
				Blockchain[i].HashThisBlock = ByteArrayToString(Blockchain[i].ByteArrayHash);
				
				Console.WriteLine("Block created with the following:");
				Console.WriteLine("Block index = " + Blockchain[i].Index);
				Console.WriteLine("Block HashPreviousBlock = " + Blockchain[i - 1].HashThisBlock); //Note we get hash of previous block in array
				Console.WriteLine("Block timestamp = " + Blockchain[i].Timestamp);
				Console.WriteLine("Block data = " + Blockchain[i].Data);
				Console.WriteLine("Block hash = " + Blockchain[i].HashThisBlock + " (hash string length = " + Blockchain[i].HashThisBlock.Length + ")");

				Console.ReadKey();
			}

			//Finish with output
			Console.WriteLine("A " + NumOfBlocks + " block blockchain has been created");
			Console.ReadKey();
		}
		static public string ByteArrayToString(Byte[] arrInput)
		{
			int i;
			string soutput = "";

			for (i = 0; i < arrInput.Length - 1; i++)
			{
				soutput += arrInput[i];
			}

			return soutput;

		}


    }
	
}
