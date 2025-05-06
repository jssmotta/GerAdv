"use client";
import { IGridComponent } from "@/app/interfaces/IGridComponent";
import StatusBiuGrid from "@/app/GerAdv_TS/StatusBiu/Crud/Grids/StatusBiuGrid";

export class StatusBiuGridAdapter implements IGridComponent {
    render(): React.ReactNode {
        return <StatusBiuGrid />;
    }
}