"use client";
import { IGridComponent } from "@/app/interfaces/IGridComponent";
import PoderJudiciarioAssociadoGrid from "@/app/GerAdv_TS/PoderJudiciarioAssociado/Crud/Grids/PoderJudiciarioAssociadoGrid";

export class PoderJudiciarioAssociadoGridAdapter implements IGridComponent {
    render(): React.ReactNode {
        return <PoderJudiciarioAssociadoGrid />;
    }
}