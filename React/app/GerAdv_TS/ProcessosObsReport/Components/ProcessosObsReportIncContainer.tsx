'use client';
import { INavigator } from '@/app/interfaces/INavigator';
import ProcessosObsReportInc from '../Crud/Inc/ProcessosObsReport';
import { getParamFromUrl } from '@/app/tools/helpers';
interface ProcessosObsReportIncContainerProps {
  id: number;
  navigator: INavigator;
}
const ProcessosObsReportIncContainer: React.FC<ProcessosObsReportIncContainerProps> = ({ id, navigator }) => {
  const handleClose = () => {};
  const handleSuccess = () => {};
  const handleError = () => {};
  return (
  <ProcessosObsReportInc
  id={id}
  onClose={handleClose}
  onSuccess={handleSuccess}
  onError={handleError}
  />
);
};
export default ProcessosObsReportIncContainer;