//CrudGrid.tsx.txt
'use client';
import { AppGridToolbar } from '@/app/components/Cruds/GridToolbar';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { DocsRecebidosItensEmpty } from '../../../Models/DocsRecebidosItens';
import { useWindow } from '@/app/hooks/useWindows';
import { useRouter } from 'next/navigation';
import { useEffect, useMemo, useState } from 'react';
import { IDocsRecebidosItens } from '../../Interfaces/interface.DocsRecebidosItens';
import { DocsRecebidosItensService } from '../../Services/DocsRecebidosItens.service';
import { DocsRecebidosItensApi } from '../../Apis/ApiDocsRecebidosItens';
import { DocsRecebidosItensGridMobileComponent } from '../GridsMobile/DocsRecebidosItens';
import { DocsRecebidosItensGridDesktopComponent } from '../GridsDesktop/DocsRecebidosItens';
import { getParamFromUrl } from '@/app/tools/helpers';
import { FilterDocsRecebidosItens } from '../../Filters/DocsRecebidosItens';
import { ConfirmationModal } from '@/app/components/Cruds/ConfirmationModal';
import DocsRecebidosItensWindow from './DocsRecebidosItensWindow';
import ErrorMessage from '@/app/components/Cruds/ErrorMessage';
import { useDocsRecebidosItensList } from '../../Hooks/hookDocsRecebidosItens';
import { LoadingSpinner } from '@/app/components/Cruds/LoadingSpinner';
import { NotifySystemActions, subscribeToNotifications } from '@/app/tools/NotifySystem';
const DocsRecebidosItensGrid: React.FC = () => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const dimensions = useWindow();

  // Service
  const docsrecebidositensService = useMemo(() => {
    return new DocsRecebidosItensService(
    new DocsRecebidosItensApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
}, [systemContext?.Uri, systemContext?.Token]);
// Hook customizado para lista
const {
  data: docsrecebidositens, 
  loading, 
  error, 
  fetchData, 
  refreshData
} = useDocsRecebidosItensList(docsrecebidositensService);
// Estados locais para UI
const [showInc, setShowInc] = useState(false);
const [selectedDocsRecebidosItens, setSelectedDocsRecebidosItens] = useState<IDocsRecebidosItens>(DocsRecebidosItensEmpty());
const [selectedId, setSelectedId] = useState<number | null>(null);
const [isModalOpen, setIsModalOpen] = useState(false);
const [deleteId, setDeleteId] = useState<number | null>(null);
const [errorMessage, setErrorMessage] = useState<string | null>(null);
const [currFilter, setCurrFilter] = useState<FilterDocsRecebidosItens | undefined | null>(null);

const reloadFilter = () => {
  handleFetchWithFilter();
};
useEffect(() => { // Ref: FILTER_FETCH2
  if (!showInc) {
    handleFetchWithFilter();
  }
}, [showInc]);
// Buscar dados com filtro
const handleFetchWithFilter = async (filtro?: FilterDocsRecebidosItens | undefined | null) => {
  setCurrFilter(filtro);
  await fetchData(filtro ?? {} as FilterDocsRecebidosItens);
};
// Handlers para o grid
const handleRowClick = (docsrecebidositens: IDocsRecebidosItens) => {
  setSelectedDocsRecebidosItens(docsrecebidositens);
  setShowInc(true);
};
const handleAdd = () => {
  setSelectedDocsRecebidosItens(DocsRecebidosItensEmpty());
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
  const docsrecebidositens = e.dataItem;
  setDeleteId(docsrecebidositens.id);
  setIsModalOpen(true);
};
const confirmDelete = async () => {
  if (deleteId !== null) {
    try {
      await docsrecebidositensService.deleteDocsRecebidosItens(deleteId);
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
    <DocsRecebidosItensGridMobileComponent
    data={docsrecebidositens}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    ) : (
    <DocsRecebidosItensGridDesktopComponent
    data={docsrecebidositens}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    )}

    <DocsRecebidosItensWindow
    isOpen={showInc}
    onClose={handleClose}
    dimensions={dimensions}
    onSuccess={handleSuccess}
    onError={handleError}
    selectedDocsRecebidosItens={selectedDocsRecebidosItens}
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
export default DocsRecebidosItensGrid;