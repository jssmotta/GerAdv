"use client";
import { IGridComponent } from "@/app/interfaces/IGridComponent";
import TipoOrigemSucumbenciaGrid from "@/app/GerAdv_TS/TipoOrigemSucumbencia/Crud/Grids/TipoOrigemSucumbenciaGrid";

export class TipoOrigemSucumbenciaGridAdapter implements IGridComponent {
    render(): React.ReactNode {
        return <TipoOrigemSucumbenciaGrid />;
    }
}