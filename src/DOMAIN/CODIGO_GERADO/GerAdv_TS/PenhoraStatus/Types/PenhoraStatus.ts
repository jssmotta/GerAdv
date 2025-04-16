import { Auditor } from "../../Models/Auditor";

export interface IPenhoraStatus {
  id: number;
	nome : string;
	auditor?: Auditor | null;
}
