'use client';
import { INavigator } from '@/app/interfaces/INavigator';
import DivisaoTribunalInc from '../Crud/Inc/DivisaoTribunal';
import { getParamFromUrl } from '@/app/tools/helpers';
interface DivisaoTribunalIncContainerProps {
  id: number;
  navigator: INavigator;
}
const DivisaoTribunalIncContainer: React.FC<DivisaoTribunalIncContainerProps> = ({ id, navigator }) => {
  const handleClose = () => {};
  const handleSuccess = () => {};
  const handleError = () => {};
  return (
  <DivisaoTribunalInc
  id={id}
  onClose={handleClose}
  onSuccess={handleSuccess}
  onError={handleError}
  />
);
};
export default DivisaoTribunalIncContainer;