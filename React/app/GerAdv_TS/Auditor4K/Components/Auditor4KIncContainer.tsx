'use client';
import { INavigator } from '@/app/interfaces/INavigator';
import Auditor4KInc from '../Crud/Inc/Auditor4K';
import { getParamFromUrl } from '@/app/tools/helpers';
interface Auditor4KIncContainerProps {
  id: number;
  navigator: INavigator;
  onSuccess: (registro?: any) => void;
}
const Auditor4KIncContainer: React.FC<Auditor4KIncContainerProps> = ({ id, navigator, onSuccess }) => {
  const handleClose = () => {};
  const handleError = () => {};
  return (
  <Auditor4KInc
  id={id}
  onClose={handleClose}
  onSuccess={onSuccess}
  onError={handleError}
  />
);
};
export default Auditor4KIncContainer;