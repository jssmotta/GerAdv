//CrudGrid.tsx.txt
"use client";
import { EditWindow } from "@/app/components/EditWindow"; 
import { AppGridToolbar } from "@/app/components/GridToolbar";
import { useIsMobile } from "@/app/context/MobileContext";
import { useSystemContext } from "@/app/context/SystemContext";
import { DocumentosEmpty } from "../../../Models/Documentos";
import { useWindow } from "@/app/hooks/useWindows";
import { useRouter } from "next/navigation";
import { useEffect, useMemo, useState } from "react";
import DocumentosInc from "../Inc/Documentos";
import { IDocumentos } from "../../Interfaces/interface.Documentos";
import { DocumentosService } from "../../Services/Documentos.service";
import { DocumentosApi } from "../../Apis/ApiDocumentos";
import { DocumentosGridMobileComponent } from "../GridsMobile/Documentos";
import { DocumentosGridDesktopComponent } from "../GridsDesktop/Documentos";
import { getParamFromUrl } from "@/app/tools/helpers";
import { FilterDocumentos } from "../../Filters/Documentos";
import { ConfirmationModal } from "@/app/components/ConfirmationModal";
import DocumentosWindow from "./DocumentosWindow";

const DocumentosGrid: React.FC = () => {
    const { systemContext } = useSystemContext();
    const isMobile = useIsMobile();
    const router = useRouter();
    const dimensions = useWindow();
    
    const [documentos, setDocumentos] = useState<IDocumentos[]>([]);
    const [showInc, setShowInc] = useState(false);
    const [selectedDocumentos, setSelectedDocumentos] = useState<IDocumentos>(DocumentosEmpty());     

    const [isModalOpen, setIsModalOpen] = useState(false);
    const [deleteId, setDeleteId] = useState<number | null>(null);
    const dadoApi = new DocumentosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');

    const [currFilter, setCurrFilter] = useState<FilterDocumentos | undefined | null>(null);

    const documentosService = useMemo(() => {
      return new DocumentosService(
          new DocumentosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
      ); 
    }, [systemContext?.Uri, systemContext?.Token]);
  
    const fetchDocumentos = async (filtro?: FilterDocumentos | undefined | null) => {
      setCurrFilter(filtro);
      if (isMobile) {
        const data = await documentosService.getAll(filtro ?? {} as FilterDocumentos);
        setDocumentos(data);
      }
      else {
        const data = await documentosService.getAll(filtro ?? {} as FilterDocumentos);
        setDocumentos(data);
      }
    };
  
    useEffect(() => { //  Ref: FILTER_FETCH
      fetchDocumentos(currFilter);
    }, [showInc]);
  
    const handleRowClick = (documentos: IDocumentos) => {
      if (isMobile) {
        router.push(`/pages/documentos/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${documentos.id}`);
      } else {
        setSelectedDocumentos(documentos);
        setShowInc(true);
      }
    };
  
    const handleAdd = () => {
      if (isMobile) {
        router.push(`/pages/documentos/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=0`);
        return;
      }
      setSelectedDocumentos(DocumentosEmpty());
      setShowInc(true);
    };
  
    const handleClose = () => {
      setShowInc(false);
    };
  
    const handleSuccess = () => {
      fetchDocumentos(currFilter);
      setShowInc(false);
    };

    const handleError = () => {
      setShowInc(false);
    };
  
    const onDeleteClick = (e: any) => {
        const documentos = e.dataItem;		
        setDeleteId(documentos.id);
        setIsModalOpen(true);
    };
      
    const confirmDelete = async () => {
        if (deleteId !== null) {
            try {
                await dadoApi.delete(deleteId);			
                fetchDocumentos(currFilter);
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
            
        {isMobile ?
           <DocumentosGridMobileComponent data={documentos} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} /> :
           <DocumentosGridDesktopComponent data={documentos} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} /> }       
     
        <DocumentosWindow
          isOpen={showInc}
          onClose={handleClose}
          dimensions={dimensions} 
          onSuccess={handleSuccess}
          onError={handleError}
          selectedDocumentos={selectedDocumentos}>       
        </DocumentosWindow>

        <ConfirmationModal 
          isOpen={isModalOpen}
          onConfirm={confirmDelete}
          onCancel={cancelDelete}
          message={`Deseja realmente excluir o registro?`} 
        />
      </>
    );
  };
  
  export default DocumentosGrid;