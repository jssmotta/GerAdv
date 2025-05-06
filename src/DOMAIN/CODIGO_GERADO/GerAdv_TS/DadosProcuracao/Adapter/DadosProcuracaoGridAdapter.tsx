"use client";
import { IGridComponent } from "@/app/interfaces/IGridComponent";
import DadosProcuracaoGrid from "@/app/GerAdv_TS/DadosProcuracao/Crud/Grids/DadosProcuracaoGrid";

export class DadosProcuracaoGridAdapter implements IGridComponent {
    render(): React.ReactNode {
        return <DadosProcuracaoGrid />;
    }
}