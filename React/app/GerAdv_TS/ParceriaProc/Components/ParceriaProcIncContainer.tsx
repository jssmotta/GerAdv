'use client';
import { INavigator } from '@/app/interfaces/INavigator';
import ParceriaProcInc from '../Crud/Inc/ParceriaProc';
import { getParamFromUrl } from '@/app/tools/helpers';
interface ParceriaProcIncContainerProps {
  id: number;
  navigator: INavigator;
}
const ParceriaProcIncContainer: React.FC<ParceriaProcIncContainerProps> = ({ id, navigator }) => {
  const handleClose = () => {};
  const handleSuccess = () => {};
  const handleError = () => {};
  return (
  <ParceriaProcInc
  id={id}
  onClose={handleClose}
  onSuccess={handleSuccess}
  onError={handleError}
  />
);
};
export default ParceriaProcIncContainer;