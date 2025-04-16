"use client";
import { IGridComponent } from "@/app/interfaces/IGridComponent";
import HonorariosDadosContratoGrid from "@/app/GerAdv_TS/HonorariosDadosContrato/Crud/Grids/HonorariosDadosContratoGrid";

export class HonorariosDadosContratoGridAdapter implements IGridComponent {
    render(): React.ReactNode {
        return <HonorariosDadosContratoGrid />;
    }
}