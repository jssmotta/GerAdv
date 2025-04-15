"use client";
import { IGridComponent } from "@/app/interfaces/IGridComponent";
import SMSAliceGrid from "@/app/GerAdv_TS/SMSAlice/Crud/Grids/SMSAliceGrid";

export class SMSAliceGridAdapter implements IGridComponent {
    render(): React.ReactNode {
        return <SMSAliceGrid />;
    }
}