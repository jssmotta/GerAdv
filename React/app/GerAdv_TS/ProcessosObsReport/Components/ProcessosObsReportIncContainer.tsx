'use client';
import { INavigator } from '@/app/interfaces/INavigator';
import ProcessosObsReportInc from '../Crud/Inc/ProcessosObsReport';
import { getParamFromUrl } from '@/app/tools/helpers';
interface ProcessosObsReportIncContainerProps {
  id: number;
  navigator: INavigator;
  onSuccess: (registro?: any) => void;
}
const ProcessosObsReportIncContainer: React.FC<ProcessosObsReportIncContainerProps> = ({ id, navigator, onSuccess }) => {
  const handleClose = () => {};
  const handleError = () => {};
  return (
  <ProcessosObsReportInc
  id={id}
  onClose={handleClose}
  onSuccess={onSuccess}
  onError={handleError}
  />
);
};
export default ProcessosObsReportIncContainer;