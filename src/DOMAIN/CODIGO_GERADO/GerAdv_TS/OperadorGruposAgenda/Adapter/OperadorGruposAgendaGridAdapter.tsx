"use client";
import { IGridComponent } from "@/app/interfaces/IGridComponent";
import OperadorGruposAgendaGrid from "@/app/GerAdv_TS/OperadorGruposAgenda/Crud/Grids/OperadorGruposAgendaGrid";

export class OperadorGruposAgendaGridAdapter implements IGridComponent {
    render(): React.ReactNode {
        return <OperadorGruposAgendaGrid />;
    }
}