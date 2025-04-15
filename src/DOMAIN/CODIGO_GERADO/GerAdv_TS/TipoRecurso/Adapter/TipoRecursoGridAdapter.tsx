"use client";
import { IGridComponent } from "@/app/interfaces/IGridComponent";
import TipoRecursoGrid from "@/app/GerAdv_TS/TipoRecurso/Crud/Grids/TipoRecursoGrid";

export class TipoRecursoGridAdapter implements IGridComponent {
    render(): React.ReactNode {
        return <TipoRecursoGrid />;
    }
}