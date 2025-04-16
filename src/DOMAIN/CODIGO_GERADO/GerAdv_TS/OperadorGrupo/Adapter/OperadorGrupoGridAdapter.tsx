"use client";
import { IGridComponent } from "@/app/interfaces/IGridComponent";
import OperadorGrupoGrid from "@/app/GerAdv_TS/OperadorGrupo/Crud/Grids/OperadorGrupoGrid";

export class OperadorGrupoGridAdapter implements IGridComponent {
    render(): React.ReactNode {
        return <OperadorGrupoGrid />;
    }
}