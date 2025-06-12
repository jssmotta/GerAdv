'use client';
import { INavigator } from '@/app/interfaces/INavigator';
import ProcessOutPutIDsInc from '../Crud/Inc/ProcessOutPutIDs';
import { getParamFromUrl } from '@/app/tools/helpers';
interface ProcessOutPutIDsIncContainerProps {
  id: number;
  navigator: INavigator;
}
const ProcessOutPutIDsIncContainer: React.FC<ProcessOutPutIDsIncContainerProps> = ({ id, navigator }) => {
  const handleClose = () => {};
  const handleSuccess = () => {};
  const handleError = () => {};
  return (
  <ProcessOutPutIDsInc
  id={id}
  onClose={handleClose}
  onSuccess={handleSuccess}
  onError={handleError}
  />
);
};
export default ProcessOutPutIDsIncContainer;