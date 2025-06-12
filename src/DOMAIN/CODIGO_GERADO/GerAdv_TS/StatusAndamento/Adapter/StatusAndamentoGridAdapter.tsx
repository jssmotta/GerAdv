'use client';
import { IGridComponent } from '@/app/interfaces/IGridComponent';
import StatusAndamentoGrid from '@/app/GerAdv_TS/StatusAndamento/Crud/Grids/StatusAndamentoGrid';
export class StatusAndamentoGridAdapter implements IGridComponent {
  render(): React.ReactNode {
    return <StatusAndamentoGrid />;
  }
}