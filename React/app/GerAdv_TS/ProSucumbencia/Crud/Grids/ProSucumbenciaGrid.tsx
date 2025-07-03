//CrudGrid.tsx.txt
'use client';
import { AppGridToolbar } from '@/app/components/Cruds/GridToolbar';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { ProSucumbenciaEmpty } from '../../../Models/ProSucumbencia';
import { useWindow } from '@/app/hooks/useWindows';
import { useRouter } from 'next/navigation';
import { useEffect, useMemo, useState } from 'react';
import { IProSucumbencia } from '../../Interfaces/interface.ProSucumbencia';
import { ProSucumbenciaService } from '../../Services/ProSucumbencia.service';
import { ProSucumbenciaApi } from '../../Apis/ApiProSucumbencia';
import { ProSucumbenciaGridMobileComponent } from '../GridsMobile/ProSucumbencia';
import { ProSucumbenciaGridDesktopComponent } from '../GridsDesktop/ProSucumbencia';
import { getParamFromUrl } from '@/app/tools/helpers';
import { FilterProSucumbencia } from '../../Filters/ProSucumbencia';
import { ConfirmationModal } from '@/app/components/Cruds/ConfirmationModal';
import ProSucumbenciaWindow from './ProSucumbenciaWindow';
import ErrorMessage from '@/app/components/Cruds/ErrorMessage';
import { useProSucumbenciaList } from '../../Hooks/hookProSucumbencia';
import { LoadingSpinner } from '@/app/components/Cruds/LoadingSpinner';
import { NotifySystemActions, subscribeToNotifications } from '@/app/tools/NotifySystem';
const ProSucumbenciaGrid: React.FC = () => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const dimensions = useWindow();

  // Service
  const prosucumbenciaService = useMemo(() => {
    return new ProSucumbenciaService(
    new ProSucumbenciaApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
}, [systemContext?.Uri, systemContext?.Token]);
// Hook customizado para lista
const {
  data: prosucumbencia, 
  loading, 
  error, 
  fetchData, 
  refreshData
} = useProSucumbenciaList(prosucumbenciaService);
// Estados locais para UI
const [showInc, setShowInc] = useState(false);
const [selectedProSucumbencia, setSelectedProSucumbencia] = useState<IProSucumbencia>(ProSucumbenciaEmpty());
const [selectedId, setSelectedId] = useState<number | null>(null);
const [isModalOpen, setIsModalOpen] = useState(false);
const [deleteId, setDeleteId] = useState<number | null>(null);
const [errorMessage, setErrorMessage] = useState<string | null>(null);
const [currFilter, setCurrFilter] = useState<FilterProSucumbencia | undefined | null>(null);

const reloadFilter = () => {
  handleFetchWithFilter();
};
useEffect(() => { // Ref: FILTER_FETCH2
  if (!showInc) {
    handleFetchWithFilter();
  }
}, [showInc]);
// Buscar dados com filtro
const handleFetchWithFilter = async (filtro?: FilterProSucumbencia | undefined | null) => {
  setCurrFilter(filtro);
  await fetchData(filtro ?? {} as FilterProSucumbencia);
};
// Handlers para o grid
const handleRowClick = (prosucumbencia: IProSucumbencia) => {
  setSelectedProSucumbencia(prosucumbencia);
  setShowInc(true);
};
const handleAdd = () => {
  setSelectedProSucumbencia(ProSucumbenciaEmpty());
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
  const prosucumbencia = e.dataItem;
  setDeleteId(prosucumbencia.id);
  setIsModalOpen(true);
};
const confirmDelete = async () => {
  if (deleteId !== null) {
    try {
      await prosucumbenciaService.deleteProSucumbencia(deleteId);
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
    if (entity.action == NotifySystemActions.ERROR) {
      return;
    }
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
    <ProSucumbenciaGridMobileComponent
    data={prosucumbencia}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    ) : (
    <ProSucumbenciaGridDesktopComponent
    data={prosucumbencia}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    )}

    <ProSucumbenciaWindow
    isOpen={showInc}
    onClose={handleClose}
    dimensions={dimensions}
    onSuccess={handleSuccess}
    onError={handleError}
    selectedProSucumbencia={selectedProSucumbencia}
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
export default ProSucumbenciaGrid;