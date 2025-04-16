"use client";
import { IGridComponent } from "@/app/interfaces/IGridComponent";
import AdvogadosGrid from "@/app/GerAdv_TS/Advogados/Crud/Grids/AdvogadosGrid";

export class AdvogadosGridAdapter implements IGridComponent {
    render(): React.ReactNode {
        return <AdvogadosGrid />;
    }
}