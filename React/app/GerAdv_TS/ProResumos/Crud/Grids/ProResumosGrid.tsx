//CrudGrid.tsx.txt
'use client';
import { AppGridToolbar } from '@/app/components/Cruds/GridToolbar';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { ProResumosEmpty } from '../../../Models/ProResumos';
import { useWindow } from '@/app/hooks/useWindows';
import { useRouter } from 'next/navigation';
import { useEffect, useMemo, useState } from 'react';
import { IProResumos } from '../../Interfaces/interface.ProResumos';
import { ProResumosService } from '../../Services/ProResumos.service';
import { ProResumosApi } from '../../Apis/ApiProResumos';
import { ProResumosGridMobileComponent } from '../GridsMobile/ProResumos';
import { ProResumosGridDesktopComponent } from '../GridsDesktop/ProResumos';
import { getParamFromUrl } from '@/app/tools/helpers';
import { FilterProResumos } from '../../Filters/ProResumos';
import { ConfirmationModal } from '@/app/components/Cruds/ConfirmationModal';
import ProResumosWindow from './ProResumosWindow';
import ErrorMessage from '@/app/components/Cruds/ErrorMessage';
import { useProResumosList } from '../../Hooks/hookProResumos';
import { LoadingSpinner } from '@/app/components/Cruds/LoadingSpinner';
import { NotifySystemActions, subscribeToNotifications } from '@/app/tools/NotifySystem';
const ProResumosGrid: React.FC = () => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const dimensions = useWindow();

  // Service
  const proresumosService = useMemo(() => {
    return new ProResumosService(
    new ProResumosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
}, [systemContext?.Uri, systemContext?.Token]);
// Hook customizado para lista
const {
  data: proresumos, 
  loading, 
  error, 
  fetchData, 
  refreshData
} = useProResumosList(proresumosService);
// Estados locais para UI
const [showInc, setShowInc] = useState(false);
const [selectedProResumos, setSelectedProResumos] = useState<IProResumos>(ProResumosEmpty());
const [selectedId, setSelectedId] = useState<number | null>(null);
const [isModalOpen, setIsModalOpen] = useState(false);
const [deleteId, setDeleteId] = useState<number | null>(null);
const [errorMessage, setErrorMessage] = useState<string | null>(null);
const [currFilter, setCurrFilter] = useState<FilterProResumos | undefined | null>(null);

const reloadFilter = () => {
  handleFetchWithFilter();
};
useEffect(() => { // Ref: FILTER_FETCH2
  if (!showInc) {
    handleFetchWithFilter();
  }
}, [showInc]);
// Buscar dados com filtro
const handleFetchWithFilter = async (filtro?: FilterProResumos | undefined | null) => {
  setCurrFilter(filtro);
  await fetchData(filtro ?? {} as FilterProResumos);
};
// Handlers para o grid
const handleRowClick = (proresumos: IProResumos) => {
  setSelectedProResumos(proresumos);
  setShowInc(true);
};
const handleAdd = () => {
  setSelectedProResumos(ProResumosEmpty());
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
  const proresumos = e.dataItem;
  setDeleteId(proresumos.id);
  setIsModalOpen(true);
};
const confirmDelete = async () => {
  if (deleteId !== null) {
    try {
      await proresumosService.deleteProResumos(deleteId);
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
    <ProResumosGridMobileComponent
    data={proresumos}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    ) : (
    <ProResumosGridDesktopComponent
    data={proresumos}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    )}

    <ProResumosWindow
    isOpen={showInc}
    onClose={handleClose}
    dimensions={dimensions}
    onSuccess={handleSuccess}
    onError={handleError}
    selectedProResumos={selectedProResumos}
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
export default ProResumosGrid;