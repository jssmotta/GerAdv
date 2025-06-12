//CrudGrid.tsx.txt
'use client';
import { AppGridToolbar } from '@/app/components/Cruds/GridToolbar';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { EnquadramentoEmpresaEmpty } from '../../../Models/EnquadramentoEmpresa';
import { useWindow } from '@/app/hooks/useWindows';
import { useRouter } from 'next/navigation';
import { useEffect, useMemo, useState } from 'react';
import { IEnquadramentoEmpresa } from '../../Interfaces/interface.EnquadramentoEmpresa';
import { EnquadramentoEmpresaService } from '../../Services/EnquadramentoEmpresa.service';
import { EnquadramentoEmpresaApi } from '../../Apis/ApiEnquadramentoEmpresa';
import { EnquadramentoEmpresaGridMobileComponent } from '../GridsMobile/EnquadramentoEmpresa';
import { EnquadramentoEmpresaGridDesktopComponent } from '../GridsDesktop/EnquadramentoEmpresa';
import { getParamFromUrl } from '@/app/tools/helpers';
import { FilterEnquadramentoEmpresa } from '../../Filters/EnquadramentoEmpresa';
import { ConfirmationModal } from '@/app/components/Cruds/ConfirmationModal';
import EnquadramentoEmpresaWindow from './EnquadramentoEmpresaWindow';
import ErrorMessage from '@/app/components/Cruds/ErrorMessage';
import { useEnquadramentoEmpresaList } from '../../Hooks/hookEnquadramentoEmpresa';
import { LoadingSpinner } from '@/app/components/Cruds/LoadingSpinner';
import { subscribeToNotifications } from '@/app/tools/NotifySystem';
const EnquadramentoEmpresaGrid: React.FC = () => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const dimensions = useWindow();

  // Service
  const enquadramentoempresaService = useMemo(() => {
    return new EnquadramentoEmpresaService(
    new EnquadramentoEmpresaApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
}, [systemContext?.Uri, systemContext?.Token]);
// Hook customizado para lista
const {
  data: enquadramentoempresa, 
  loading, 
  error, 
  fetchData, 
  refreshData
} = useEnquadramentoEmpresaList(enquadramentoempresaService);
// Estados locais para UI
const [showInc, setShowInc] = useState(false);
const [selectedEnquadramentoEmpresa, setSelectedEnquadramentoEmpresa] = useState<IEnquadramentoEmpresa>(EnquadramentoEmpresaEmpty());
const [selectedId, setSelectedId] = useState<number | null>(null);
const [isModalOpen, setIsModalOpen] = useState(false);
const [deleteId, setDeleteId] = useState<number | null>(null);
const [errorMessage, setErrorMessage] = useState<string | null>(null);
const [currFilter, setCurrFilter] = useState<FilterEnquadramentoEmpresa | undefined | null>(null);

const reloadFilter = () => {
  handleFetchWithFilter();
};
useEffect(() => { // Ref: FILTER_FETCH2
  if (!showInc) {
    handleFetchWithFilter();
  }
}, [showInc]);
// Buscar dados com filtro
const handleFetchWithFilter = async (filtro?: FilterEnquadramentoEmpresa | undefined | null) => {
  setCurrFilter(filtro);
  await fetchData(filtro ?? {} as FilterEnquadramentoEmpresa);
};
// Handlers para o grid
const handleRowClick = (enquadramentoempresa: IEnquadramentoEmpresa) => {
  setSelectedEnquadramentoEmpresa(enquadramentoempresa);
  setShowInc(true);
};
const handleAdd = () => {
  setSelectedEnquadramentoEmpresa(EnquadramentoEmpresaEmpty());
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
  const enquadramentoempresa = e.dataItem;
  setDeleteId(enquadramentoempresa.id);
  setIsModalOpen(true);
};
const confirmDelete = async () => {
  if (deleteId !== null) {
    try {
      await enquadramentoempresaService.deleteEnquadramentoEmpresa(deleteId);
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
    <EnquadramentoEmpresaGridMobileComponent
    data={enquadramentoempresa}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    ) : (
    <EnquadramentoEmpresaGridDesktopComponent
    data={enquadramentoempresa}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    )}

    <EnquadramentoEmpresaWindow
    isOpen={showInc}
    onClose={handleClose}
    dimensions={dimensions}
    onSuccess={handleSuccess}
    onError={handleError}
    selectedEnquadramentoEmpresa={selectedEnquadramentoEmpresa}
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
export default EnquadramentoEmpresaGrid;