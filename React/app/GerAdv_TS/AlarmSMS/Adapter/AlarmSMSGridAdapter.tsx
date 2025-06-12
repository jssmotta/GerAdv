'use client';
import { IGridComponent } from '@/app/interfaces/IGridComponent';
import AlarmSMSGrid from '@/app/GerAdv_TS/AlarmSMS/Crud/Grids/AlarmSMSGrid';
export class AlarmSMSGridAdapter implements IGridComponent {
  render(): React.ReactNode {
    return <AlarmSMSGrid />;
  }
}