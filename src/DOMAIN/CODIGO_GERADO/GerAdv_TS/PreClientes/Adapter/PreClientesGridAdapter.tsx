"use client";
import { IGridComponent } from "@/app/interfaces/IGridComponent";
import PreClientesGrid from "@/app/GerAdv_TS/PreClientes/Crud/Grids/PreClientesGrid";

export class PreClientesGridAdapter implements IGridComponent {
    render(): React.ReactNode {
        return <PreClientesGrid />;
    }
}