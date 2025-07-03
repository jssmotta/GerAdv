'use client';
import { INavigator } from '@/app/interfaces/INavigator';
import ProcessOutPutIDsInc from '../Crud/Inc/ProcessOutPutIDs';
import { getParamFromUrl } from '@/app/tools/helpers';
interface ProcessOutPutIDsIncContainerProps {
  id: number;
  navigator: INavigator;
  onSuccess: (registro?: any) => void;
}
const ProcessOutPutIDsIncContainer: React.FC<ProcessOutPutIDsIncContainerProps> = ({ id, navigator, onSuccess }) => {
  const handleClose = () => {};
  const handleError = () => {};
  return (
  <ProcessOutPutIDsInc
  id={id}
  onClose={handleClose}
  onSuccess={onSuccess}
  onError={handleError}
  />
);
};
export default ProcessOutPutIDsIncContainer;