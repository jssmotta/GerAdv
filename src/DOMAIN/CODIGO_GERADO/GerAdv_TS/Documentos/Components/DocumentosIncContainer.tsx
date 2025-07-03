'use client';
import { INavigator } from '@/app/interfaces/INavigator';
import DocumentosInc from '../Crud/Inc/Documentos';
import { getParamFromUrl } from '@/app/tools/helpers';
interface DocumentosIncContainerProps {
  id: number;
  navigator: INavigator;
  onSuccess: (registro?: any) => void;
}
const DocumentosIncContainer: React.FC<DocumentosIncContainerProps> = ({ id, navigator, onSuccess }) => {
  const handleClose = () => {};
  const handleError = () => {};
  return (
  <DocumentosInc
  id={id}
  onClose={handleClose}
  onSuccess={onSuccess}
  onError={handleError}
  />
);
};
export default DocumentosIncContainer;