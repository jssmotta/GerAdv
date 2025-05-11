"use client";
import { IGridComponent } from "@/app/interfaces/IGridComponent";
import ColaboradoresGrid from "@/app/GerAdv_TS/Colaboradores/Crud/Grids/ColaboradoresGrid";

export class ColaboradoresGridAdapter implements IGridComponent {
    render(): React.ReactNode {
        return <ColaboradoresGrid />;
    }
}