//CrudGrid.tsx.txt
'use client';
import { AppGridToolbar } from '@/app/components/Cruds/GridToolbar';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { ProValoresEmpty } from '../../../Models/ProValores';
import { useWindow } from '@/app/hooks/useWindows';
import { useRouter } from 'next/navigation';
import { useEffect, useMemo, useState } from 'react';
import { IProValores } from '../../Interfaces/interface.ProValores';
import { ProValoresService } from '../../Services/ProValores.service';
import { ProValoresApi } from '../../Apis/ApiProValores';
import { ProValoresGridMobileComponent } from '../GridsMobile/ProValores';
import { ProValoresGridDesktopComponent } from '../GridsDesktop/ProValores';
import { getParamFromUrl } from '@/app/tools/helpers';
import { FilterProValores } from '../../Filters/ProValores';
import { ConfirmationModal } from '@/app/components/Cruds/ConfirmationModal';
import ProValoresWindow from './ProValoresWindow';
import ErrorMessage from '@/app/components/Cruds/ErrorMessage';
import { useProValoresList } from '../../Hooks/hookProValores';
import { LoadingSpinner } from '@/app/components/Cruds/LoadingSpinner';
import { subscribeToNotifications } from '@/app/tools/NotifySystem';
const ProValoresGrid: React.FC = () => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const dimensions = useWindow();

  // Service
  const provaloresService = useMemo(() => {
    return new ProValoresService(
    new ProValoresApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
}, [systemContext?.Uri, systemContext?.Token]);
// Hook customizado para lista
const {
  data: provalores, 
  loading, 
  error, 
  fetchData, 
  refreshData
} = useProValoresList(provaloresService);
// Estados locais para UI
const [showInc, setShowInc] = useState(false);
const [selectedProValores, setSelectedProValores] = useState<IProValores>(ProValoresEmpty());
const [selectedId, setSelectedId] = useState<number | null>(null);
const [isModalOpen, setIsModalOpen] = useState(false);
const [deleteId, setDeleteId] = useState<number | null>(null);
const [errorMessage, setErrorMessage] = useState<string | null>(null);
const [currFilter, setCurrFilter] = useState<FilterProValores | undefined | null>(null);

const reloadFilter = () => {
  handleFetchWithFilter();
};
useEffect(() => { // Ref: FILTER_FETCH2
  if (!showInc) {
    handleFetchWithFilter();
  }
}, [showInc]);
// Buscar dados com filtro
const handleFetchWithFilter = async (filtro?: FilterProValores | undefined | null) => {
  setCurrFilter(filtro);
  await fetchData(filtro ?? {} as FilterProValores);
};
// Handlers para o grid
const handleRowClick = (provalores: IProValores) => {
  setSelectedProValores(provalores);
  setShowInc(true);
};
const handleAdd = () => {
  setSelectedProValores(ProValoresEmpty());
  setShowInc(true);
};
const handleClose = () => {
  setShowInc(false);
};
const handleSuccess = () => {
  setShowInc(false);
  // O hook já escuta as notificações e recarrega automaticamente
};
const handleError = () => {
  setShowInc(false);
};
// Handlers para exclusão
const onDeleteClick = (e: any) => {
  const provalores = e.dataItem;
  setDeleteId(provalores.id);
  setIsModalOpen(true);
};
const confirmDelete = async () => {
  if (deleteId !== null) {
    try {
      await provaloresService.deleteProValores(deleteId);
      // O hook já escuta as notificações e recarrega automaticamente
    } catch (error) {
    console.error('Erro ao excluir:', error);
    setErrorMessage('Erro ao excluir o registro. Verifique se ele não está vinculado a outros registros.');
  } finally {
  setDeleteId(null);
  setIsModalOpen(false);
}
}
};
const cancelDelete = () => {
  setDeleteId(null);
  setIsModalOpen(false);
};
// Combinar erro do hook com erro local
const displayError = error || errorMessage;
useEffect(() => {
  const unsubscribe = subscribeToNotifications('*', (entity) => {
    reloadFilter();
  });
  return () => {
    unsubscribe();
  };
}, []);
return (
<>
<AppGridToolbar onAdd={handleAdd} />
{loading && (
  <LoadingSpinner />
  )}
  {isMobile ? (
    <ProValoresGridMobileComponent
    data={provalores}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    ) : (
    <ProValoresGridDesktopComponent
    data={provalores}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    )}

    <ProValoresWindow
    isOpen={showInc}
    onClose={handleClose}
    dimensions={dimensions}
    onSuccess={handleSuccess}
    onError={handleError}
    selectedProValores={selectedProValores}
    />
    <ConfirmationModal
    isOpen={isModalOpen}
    onConfirm={confirmDelete}
    onCancel={cancelDelete}
    message={`Deseja realmente excluir o registro?`}
    />
    <ErrorMessage
    mensagem={displayError}
    setErrorMessage={setErrorMessage}
    />
  </>
);
};
export default ProValoresGrid;