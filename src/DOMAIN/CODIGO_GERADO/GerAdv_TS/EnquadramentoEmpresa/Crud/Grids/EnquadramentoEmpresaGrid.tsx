//CrudGrid.tsx.txt
"use client";
import { EditWindow } from "@/app/components/EditWindow"; 
import { AppGridToolbar } from "@/app/components/GridToolbar";
import { useIsMobile } from "@/app/context/MobileContext";
import { useSystemContext } from "@/app/context/SystemContext";
import { EnquadramentoEmpresaEmpty } from "../../../Models/EnquadramentoEmpresa";
import { useWindow } from "@/app/hooks/useWindows";
import { useRouter } from "next/navigation";
import { useEffect, useMemo, useState } from "react";
import EnquadramentoEmpresaInc from "../Inc/EnquadramentoEmpresa";
import { IEnquadramentoEmpresa } from "../../Interfaces/interface.EnquadramentoEmpresa";
import { EnquadramentoEmpresaService } from "../../Services/EnquadramentoEmpresa.service";
import { EnquadramentoEmpresaApi } from "../../Apis/ApiEnquadramentoEmpresa";
import { EnquadramentoEmpresaGridMobileComponent } from "../GridsMobile/EnquadramentoEmpresa";
import { EnquadramentoEmpresaGridDesktopComponent } from "../GridsDesktop/EnquadramentoEmpresa";
import { getParamFromUrl } from "@/app/tools/helpers";
import { FilterEnquadramentoEmpresa } from "../../Filters/EnquadramentoEmpresa";
import { ConfirmationModal } from "@/app/components/ConfirmationModal";
import EnquadramentoEmpresaWindow from "./EnquadramentoEmpresaWindow";

const EnquadramentoEmpresaGrid: React.FC = () => {
    const { systemContext } = useSystemContext();
    const isMobile = useIsMobile();
    const router = useRouter();
    const dimensions = useWindow();
    
    const [enquadramentoempresa, setEnquadramentoEmpresa] = useState<IEnquadramentoEmpresa[]>([]);
    const [showInc, setShowInc] = useState(false);
    const [selectedEnquadramentoEmpresa, setSelectedEnquadramentoEmpresa] = useState<IEnquadramentoEmpresa>(EnquadramentoEmpresaEmpty());     

    const [isModalOpen, setIsModalOpen] = useState(false);
    const [deleteId, setDeleteId] = useState<number | null>(null);
    const dadoApi = new EnquadramentoEmpresaApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');

    const [currFilter, setCurrFilter] = useState<FilterEnquadramentoEmpresa | undefined | null>(null);

    const enquadramentoempresaService = useMemo(() => {
      return new EnquadramentoEmpresaService(
          new EnquadramentoEmpresaApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
      ); 
    }, [systemContext?.Uri, systemContext?.Token]);
  
    const fetchEnquadramentoEmpresa = async (filtro?: FilterEnquadramentoEmpresa | undefined | null) => {
      setCurrFilter(filtro);
      if (isMobile) {
        const data = await enquadramentoempresaService.getList(filtro ?? {} as FilterEnquadramentoEmpresa);
        setEnquadramentoEmpresa(data);
      }
      else {
        const data = await enquadramentoempresaService.getAll(filtro ?? {} as FilterEnquadramentoEmpresa);
        setEnquadramentoEmpresa(data);
      }
    };
  
    useEffect(() => { //  Ref: FILTER_FETCH
      fetchEnquadramentoEmpresa(currFilter);
    }, [showInc]);
  
    const handleRowClick = (enquadramentoempresa: IEnquadramentoEmpresa) => {
      if (isMobile) {
        router.push(`/pages/enquadramentoempresa/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${enquadramentoempresa.id}`);
      } else {
        setSelectedEnquadramentoEmpresa(enquadramentoempresa);
        setShowInc(true);
      }
    };
  
    const handleAdd = () => {
      if (isMobile) {
        router.push(`/pages/enquadramentoempresa/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=0`);
        return;
      }
      setSelectedEnquadramentoEmpresa(EnquadramentoEmpresaEmpty());
      setShowInc(true);
    };
  
    const handleClose = () => {
      setShowInc(false);
    };
  
    const handleSuccess = () => {
      fetchEnquadramentoEmpresa(currFilter);
      setShowInc(false);
    };

    const handleError = () => {
      setShowInc(false);
    };
  
    const onDeleteClick = (e: any) => {
        const enquadramentoempresa = e.dataItem;		
        setDeleteId(enquadramentoempresa.id);
        setIsModalOpen(true);
    };
      
    const confirmDelete = async () => {
        if (deleteId !== null) {
            try {
                await dadoApi.delete(deleteId);			
                fetchEnquadramentoEmpresa(currFilter);
            } catch {
            // falta uma mensagem de erro
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

    return (
      <>
        <AppGridToolbar onAdd={handleAdd} />    

        {isMobile ?
           <EnquadramentoEmpresaGridMobileComponent data={enquadramentoempresa} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} /> :
           <EnquadramentoEmpresaGridDesktopComponent data={enquadramentoempresa} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} /> }       
     
        <EnquadramentoEmpresaWindow
          isOpen={showInc}
          onClose={handleClose}
          dimensions={dimensions} 
          onSuccess={handleSuccess}
          onError={handleError}
          selectedEnquadramentoEmpresa={selectedEnquadramentoEmpresa}>       
        </EnquadramentoEmpresaWindow>

        <ConfirmationModal 
          isOpen={isModalOpen}
          onConfirm={confirmDelete}
          onCancel={cancelDelete}
          message={`Deseja realmente excluir o registro?`} 
        />
      </>
    );
  };
  
  export default EnquadramentoEmpresaGrid;