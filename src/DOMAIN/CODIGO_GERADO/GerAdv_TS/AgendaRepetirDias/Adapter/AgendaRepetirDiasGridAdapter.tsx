"use client";
import { IGridComponent } from "@/app/interfaces/IGridComponent";
import AgendaRepetirDiasGrid from "@/app/GerAdv_TS/AgendaRepetirDias/Crud/Grids/AgendaRepetirDiasGrid";

export class AgendaRepetirDiasGridAdapter implements IGridComponent {
    render(): React.ReactNode {
        return <AgendaRepetirDiasGrid />;
    }
}