"use client";
import { IGridComponent } from "@/app/interfaces/IGridComponent";
import OperadorGruposAgendaOperadoresGrid from "@/app/GerAdv_TS/OperadorGruposAgendaOperadores/Crud/Grids/OperadorGruposAgendaOperadoresGrid";

export class OperadorGruposAgendaOperadoresGridAdapter implements IGridComponent {
    render(): React.ReactNode {
        return <OperadorGruposAgendaOperadoresGrid />;
    }
}