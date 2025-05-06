//CrudGrid.tsx.txt
"use client";
import { AppGridToolbar } from "@/app/components/Cruds/GridToolbar";
import { useIsMobile } from "@/app/context/MobileContext";
import { useSystemContext } from "@/app/context/SystemContext";
import { ContatoCRMEmpty } from "../../../Models/ContatoCRM";
import { useWindow } from "@/app/hooks/useWindows";
import { useRouter } from "next/navigation";
import { useEffect, useMemo, useState } from "react";
import { IContatoCRM } from "../../Interfaces/interface.ContatoCRM";
import { ContatoCRMService } from "../../Services/ContatoCRM.service";
import { ContatoCRMApi } from "../../Apis/ApiContatoCRM";
import { ContatoCRMGridMobileComponent } from "../GridsMobile/ContatoCRM";
import { ContatoCRMGridDesktopComponent } from "../GridsDesktop/ContatoCRM";
import { getParamFromUrl } from "@/app/tools/helpers";
import { FilterContatoCRM } from "../../Filters/ContatoCRM";
import { ConfirmationModal } from "@/app/components/Cruds/ConfirmationModal";
import ContatoCRMWindow from "./ContatoCRMWindow";

const ContatoCRMGrid: React.FC = () => {
    const { systemContext } = useSystemContext();
    const [selectedId, setSelectedId] = useState<number | null>(null);
    const isMobile = useIsMobile();
    const router = useRouter();
    const dimensions = useWindow();
    
    const [contatocrm, setContatoCRM] = useState<IContatoCRM[]>([]);
    const [showInc, setShowInc] = useState(false);
    const [selectedContatoCRM, setSelectedContatoCRM] = useState<IContatoCRM>(ContatoCRMEmpty());     

    const [isModalOpen, setIsModalOpen] = useState(false);
    const [deleteId, setDeleteId] = useState<number | null>(null);
    const dadoApi = new ContatoCRMApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');

    const [currFilter, setCurrFilter] = useState<FilterContatoCRM | undefined | null>(null);

    const contatocrmService = useMemo(() => {
      return new ContatoCRMService(
          new ContatoCRMApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
      ); 
    }, [systemContext?.Uri, systemContext?.Token]);
  
    const fetchContatoCRM = async (filtro?: FilterContatoCRM | undefined | null) => {
      setCurrFilter(filtro);
      if (isMobile) {
        const data = await contatocrmService.getAll(filtro ?? {} as FilterContatoCRM);
        setContatoCRM(data);
      }
      else {
        const data = await contatocrmService.getAll(filtro ?? {} as FilterContatoCRM);
        setContatoCRM(data);
      }
    };
  
    useEffect(() => { //  Ref: FILTER_FETCH
      fetchContatoCRM(currFilter);
    }, [showInc]);
  
    const handleRowClick = (contatocrm: IContatoCRM) => {
      if (isMobile) {
        router.push(`/pages/contatocrm/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${contatocrm.id}`);
      } else {
        setSelectedContatoCRM(contatocrm);
        setShowInc(true);
      }
    };
  
    const handleAdd = () => {
      if (isMobile) {
        router.push(`/pages/contatocrm/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=0`);
        return;
      }
      setSelectedContatoCRM(ContatoCRMEmpty());
      setShowInc(true);
    };
  
    const handleClose = () => {
      setShowInc(false);
    };
  
    const handleSuccess = () => {
      fetchContatoCRM(currFilter);
      setShowInc(false);
    };

    const handleError = () => {
      setShowInc(false);
    };
  
    const onDeleteClick = (e: any) => {
        const contatocrm = e.dataItem;		
        setDeleteId(contatocrm.id);
        setIsModalOpen(true);
    };
      
    const confirmDelete = async () => {
        if (deleteId !== null) {
            try {
                await dadoApi.delete(deleteId);			
                fetchContatoCRM(currFilter);
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
           <ContatoCRMGridMobileComponent data={contatocrm} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} setSelectedId={setSelectedId}  /> :
           <ContatoCRMGridDesktopComponent data={contatocrm} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} setSelectedId={setSelectedId}  /> }       
     
        <ContatoCRMWindow
          isOpen={showInc}
          onClose={handleClose}
          dimensions={dimensions} 
          onSuccess={handleSuccess}
          onError={handleError}
          selectedContatoCRM={selectedContatoCRM}>       
        </ContatoCRMWindow>

        <ConfirmationModal 
          isOpen={isModalOpen}
          onConfirm={confirmDelete}
          onCancel={cancelDelete}
          message={`Deseja realmente excluir o registro?`} 
        />
      </>
    );
  };
  
  export default ContatoCRMGrid;