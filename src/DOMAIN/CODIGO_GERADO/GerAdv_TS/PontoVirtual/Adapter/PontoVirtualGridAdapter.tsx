"use client";
import { IGridComponent } from "@/app/interfaces/IGridComponent";
import PontoVirtualGrid from "@/app/GerAdv_TS/PontoVirtual/Crud/Grids/PontoVirtualGrid";

export class PontoVirtualGridAdapter implements IGridComponent {
    render(): React.ReactNode {
        return <PontoVirtualGrid />;
    }
}