import { Auditor } from "../../Models/Auditor";

export interface IPenhoraStatus {
  id: number;
	nome : string;
	guid : string;
	auditor?: Auditor | null;
}
