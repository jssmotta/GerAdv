"use client";
import { IGridComponent } from "@/app/interfaces/IGridComponent";
import PontoVirtualAcessosGrid from "@/app/GerAdv_TS/PontoVirtualAcessos/Crud/Grids/PontoVirtualAcessosGrid";

export class PontoVirtualAcessosGridAdapter implements IGridComponent {
    render(): React.ReactNode {
        return <PontoVirtualAcessosGrid />;
    }
}