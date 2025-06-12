//CrudGrid.tsx.txt
'use client';
import { AppGridToolbar } from '@/app/components/Cruds/GridToolbar';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { ReuniaoEmpty } from '../../../Models/Reuniao';
import { useWindow } from '@/app/hooks/useWindows';
import { useRouter } from 'next/navigation';
import { useEffect, useMemo, useState } from 'react';
import { IReuniao } from '../../Interfaces/interface.Reuniao';
import { ReuniaoService } from '../../Services/Reuniao.service';
import { ReuniaoApi } from '../../Apis/ApiReuniao';
import { ReuniaoGridMobileComponent } from '../GridsMobile/Reuniao';
import { ReuniaoGridDesktopComponent } from '../GridsDesktop/Reuniao';
import { getParamFromUrl } from '@/app/tools/helpers';
import { FilterReuniao } from '../../Filters/Reuniao';
import { ConfirmationModal } from '@/app/components/Cruds/ConfirmationModal';
import ReuniaoWindow from './ReuniaoWindow';
import ErrorMessage from '@/app/components/Cruds/ErrorMessage';
import { useReuniaoList } from '../../Hooks/hookReuniao';
import { LoadingSpinner } from '@/app/components/Cruds/LoadingSpinner';
import { subscribeToNotifications } from '@/app/tools/NotifySystem';
const ReuniaoGrid: React.FC = () => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const dimensions = useWindow();

  // Service
  const reuniaoService = useMemo(() => {
    return new ReuniaoService(
    new ReuniaoApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
}, [systemContext?.Uri, systemContext?.Token]);
// Hook customizado para lista
const {
  data: reuniao, 
  loading, 
  error, 
  fetchData, 
  refreshData
} = useReuniaoList(reuniaoService);
// Estados locais para UI
const [showInc, setShowInc] = useState(false);
const [selectedReuniao, setSelectedReuniao] = useState<IReuniao>(ReuniaoEmpty());
const [selectedId, setSelectedId] = useState<number | null>(null);
const [isModalOpen, setIsModalOpen] = useState(false);
const [deleteId, setDeleteId] = useState<number | null>(null);
const [errorMessage, setErrorMessage] = useState<string | null>(null);
const [currFilter, setCurrFilter] = useState<FilterReuniao | undefined | null>(null);

const reloadFilter = () => {
  handleFetchWithFilter();
};
useEffect(() => { // Ref: FILTER_FETCH2
  if (!showInc) {
    handleFetchWithFilter();
  }
}, [showInc]);
// Buscar dados com filtro
const handleFetchWithFilter = async (filtro?: FilterReuniao | undefined | null) => {
  setCurrFilter(filtro);
  await fetchData(filtro ?? {} as FilterReuniao);
};
// Handlers para o grid
const handleRowClick = (reuniao: IReuniao) => {
  setSelectedReuniao(reuniao);
  setShowInc(true);
};
const handleAdd = () => {
  setSelectedReuniao(ReuniaoEmpty());
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
  const reuniao = e.dataItem;
  setDeleteId(reuniao.id);
  setIsModalOpen(true);
};
const confirmDelete = async () => {
  if (deleteId !== null) {
    try {
      await reuniaoService.deleteReuniao(deleteId);
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
    <ReuniaoGridMobileComponent
    data={reuniao}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    ) : (
    <ReuniaoGridDesktopComponent
    data={reuniao}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    )}

    <ReuniaoWindow
    isOpen={showInc}
    onClose={handleClose}
    dimensions={dimensions}
    onSuccess={handleSuccess}
    onError={handleError}
    selectedReuniao={selectedReuniao}
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
export default ReuniaoGrid;