//CrudGrid.tsx.txt
'use client';
import { AppGridToolbar } from '@/app/components/Cruds/GridToolbar';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { EnderecoSistemaEmpty } from '../../../Models/EnderecoSistema';
import { useWindow } from '@/app/hooks/useWindows';
import { useRouter } from 'next/navigation';
import { useEffect, useMemo, useState } from 'react';
import { IEnderecoSistema } from '../../Interfaces/interface.EnderecoSistema';
import { EnderecoSistemaService } from '../../Services/EnderecoSistema.service';
import { EnderecoSistemaApi } from '../../Apis/ApiEnderecoSistema';
import { EnderecoSistemaGridMobileComponent } from '../GridsMobile/EnderecoSistema';
import { EnderecoSistemaGridDesktopComponent } from '../GridsDesktop/EnderecoSistema';
import { getParamFromUrl } from '@/app/tools/helpers';
import { FilterEnderecoSistema } from '../../Filters/EnderecoSistema';
import { ConfirmationModal } from '@/app/components/Cruds/ConfirmationModal';
import EnderecoSistemaWindow from './EnderecoSistemaWindow';
import ErrorMessage from '@/app/components/Cruds/ErrorMessage';
import { useEnderecoSistemaList } from '../../Hooks/hookEnderecoSistema';
import { LoadingSpinner } from '@/app/components/Cruds/LoadingSpinner';
import { subscribeToNotifications } from '@/app/tools/NotifySystem';
const EnderecoSistemaGrid: React.FC = () => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const dimensions = useWindow();

  // Service
  const enderecosistemaService = useMemo(() => {
    return new EnderecoSistemaService(
    new EnderecoSistemaApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
}, [systemContext?.Uri, systemContext?.Token]);
// Hook customizado para lista
const {
  data: enderecosistema, 
  loading, 
  error, 
  fetchData, 
  refreshData
} = useEnderecoSistemaList(enderecosistemaService);
// Estados locais para UI
const [showInc, setShowInc] = useState(false);
const [selectedEnderecoSistema, setSelectedEnderecoSistema] = useState<IEnderecoSistema>(EnderecoSistemaEmpty());
const [selectedId, setSelectedId] = useState<number | null>(null);
const [isModalOpen, setIsModalOpen] = useState(false);
const [deleteId, setDeleteId] = useState<number | null>(null);
const [errorMessage, setErrorMessage] = useState<string | null>(null);
const [currFilter, setCurrFilter] = useState<FilterEnderecoSistema | undefined | null>(null);

const reloadFilter = () => {
  handleFetchWithFilter();
};
useEffect(() => { // Ref: FILTER_FETCH2
  if (!showInc) {
    handleFetchWithFilter();
  }
}, [showInc]);
// Buscar dados com filtro
const handleFetchWithFilter = async (filtro?: FilterEnderecoSistema | undefined | null) => {
  setCurrFilter(filtro);
  await fetchData(filtro ?? {} as FilterEnderecoSistema);
};
// Handlers para o grid
const handleRowClick = (enderecosistema: IEnderecoSistema) => {
  setSelectedEnderecoSistema(enderecosistema);
  setShowInc(true);
};
const handleAdd = () => {
  setSelectedEnderecoSistema(EnderecoSistemaEmpty());
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
  const enderecosistema = e.dataItem;
  setDeleteId(enderecosistema.id);
  setIsModalOpen(true);
};
const confirmDelete = async () => {
  if (deleteId !== null) {
    try {
      await enderecosistemaService.deleteEnderecoSistema(deleteId);
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
    <EnderecoSistemaGridMobileComponent
    data={enderecosistema}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    ) : (
    <EnderecoSistemaGridDesktopComponent
    data={enderecosistema}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    )}

    <EnderecoSistemaWindow
    isOpen={showInc}
    onClose={handleClose}
    dimensions={dimensions}
    onSuccess={handleSuccess}
    onError={handleError}
    selectedEnderecoSistema={selectedEnderecoSistema}
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
export default EnderecoSistemaGrid;