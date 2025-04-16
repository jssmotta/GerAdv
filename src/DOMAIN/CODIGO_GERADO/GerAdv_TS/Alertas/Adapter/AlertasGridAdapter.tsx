"use client";
import { IGridComponent } from "@/app/interfaces/IGridComponent";
import AlertasGrid from "@/app/GerAdv_TS/Alertas/Crud/Grids/AlertasGrid";

export class AlertasGridAdapter implements IGridComponent {
    render(): React.ReactNode {
        return <AlertasGrid />;
    }
}