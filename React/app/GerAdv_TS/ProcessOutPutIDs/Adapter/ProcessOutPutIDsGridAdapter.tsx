'use client';
import { IGridComponent } from '@/app/interfaces/IGridComponent';
import ProcessOutPutIDsGrid from '@/app/GerAdv_TS/ProcessOutPutIDs/Crud/Grids/ProcessOutPutIDsGrid';
export class ProcessOutPutIDsGridAdapter implements IGridComponent {
  render(): React.ReactNode {
    return <ProcessOutPutIDsGrid />;
  }
}