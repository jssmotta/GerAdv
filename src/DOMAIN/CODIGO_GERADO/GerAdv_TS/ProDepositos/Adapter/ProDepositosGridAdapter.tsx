"use client";
import { IGridComponent } from "@/app/interfaces/IGridComponent";
import ProDepositosGrid from "@/app/GerAdv_TS/ProDepositos/Crud/Grids/ProDepositosGrid";

export class ProDepositosGridAdapter implements IGridComponent {
    render(): React.ReactNode {
        return <ProDepositosGrid />;
    }
}