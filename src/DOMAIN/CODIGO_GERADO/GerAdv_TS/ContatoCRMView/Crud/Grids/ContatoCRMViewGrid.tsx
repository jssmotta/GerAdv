//CrudGrid.tsx.txt
"use client";
import { EditWindow } from "@/app/components/EditWindow"; 
import { AppGridToolbar } from "@/app/components/GridToolbar";
import { useIsMobile } from "@/app/context/MobileContext";
import { useSystemContext } from "@/app/context/SystemContext";
import { ContatoCRMViewEmpty } from "../../../Models/ContatoCRMView";
import { useWindow } from "@/app/hooks/useWindows";
import { useRouter } from "next/navigation";
import { useEffect, useMemo, useState } from "react";
import ContatoCRMViewInc from "../Inc/ContatoCRMView";
import { IContatoCRMView } from "../../Interfaces/interface.ContatoCRMView";
import { ContatoCRMViewService } from "../../Services/ContatoCRMView.service";
import { ContatoCRMViewApi } from "../../Apis/ApiContatoCRMView";
import { ContatoCRMViewGridMobileComponent } from "../GridsMobile/ContatoCRMView";
import { ContatoCRMViewGridDesktopComponent } from "../GridsDesktop/ContatoCRMView";
import { getParamFromUrl } from "@/app/tools/helpers";
import { FilterContatoCRMView } from "../../Filters/ContatoCRMView";
import { ConfirmationModal } from "@/app/components/ConfirmationModal";
import ContatoCRMViewWindow from "./ContatoCRMViewWindow";

const ContatoCRMViewGrid: React.FC = () => {
    const { systemContext } = useSystemContext();
    const isMobile = useIsMobile();
    const router = useRouter();
    const dimensions = useWindow();
    
    const [contatocrmview, setContatoCRMView] = useState<IContatoCRMView[]>([]);
    const [showInc, setShowInc] = useState(false);
    const [selectedContatoCRMView, setSelectedContatoCRMView] = useState<IContatoCRMView>(ContatoCRMViewEmpty());     

    const [isModalOpen, setIsModalOpen] = useState(false);
    const [deleteId, setDeleteId] = useState<number | null>(null);
    const dadoApi = new ContatoCRMViewApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');

    const [currFilter, setCurrFilter] = useState<FilterContatoCRMView | undefined | null>(null);

    const contatocrmviewService = useMemo(() => {
      return new ContatoCRMViewService(
          new ContatoCRMViewApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
      ); 
    }, [systemContext?.Uri, systemContext?.Token]);
  
    const fetchContatoCRMView = async (filtro?: FilterContatoCRMView | undefined | null) => {
      setCurrFilter(filtro);
      if (isMobile) {
        const data = await contatocrmviewService.getAll(filtro ?? {} as FilterContatoCRMView);
        setContatoCRMView(data);
      }
      else {
        const data = await contatocrmviewService.getAll(filtro ?? {} as FilterContatoCRMView);
        setContatoCRMView(data);
      }
    };
  
    useEffect(() => { //  Ref: FILTER_FETCH
      fetchContatoCRMView(currFilter);
    }, [showInc]);
  
    const handleRowClick = (contatocrmview: IContatoCRMView) => {
      if (isMobile) {
        router.push(`/pages/contatocrmview/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${contatocrmview.id}`);
      } else {
        setSelectedContatoCRMView(contatocrmview);
        setShowInc(true);
      }
    };
  
    const handleAdd = () => {
      if (isMobile) {
        router.push(`/pages/contatocrmview/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=0`);
        return;
      }
      setSelectedContatoCRMView(ContatoCRMViewEmpty());
      setShowInc(true);
    };
  
    const handleClose = () => {
      setShowInc(false);
    };
  
    const handleSuccess = () => {
      fetchContatoCRMView(currFilter);
      setShowInc(false);
    };

    const handleError = () => {
      setShowInc(false);
    };
  
    const onDeleteClick = (e: any) => {
        const contatocrmview = e.dataItem;		
        setDeleteId(contatocrmview.id);
        setIsModalOpen(true);
    };
      
    const confirmDelete = async () => {
        if (deleteId !== null) {
            try {
                await dadoApi.delete(deleteId);			
                fetchContatoCRMView(currFilter);
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
           <ContatoCRMViewGridMobileComponent data={contatocrmview} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} /> :
           <ContatoCRMViewGridDesktopComponent data={contatocrmview} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} /> }       
     
        <ContatoCRMViewWindow
          isOpen={showInc}
          onClose={handleClose}
          dimensions={dimensions} 
          onSuccess={handleSuccess}
          onError={handleError}
          selectedContatoCRMView={selectedContatoCRMView}>       
        </ContatoCRMViewWindow>

        <ConfirmationModal 
          isOpen={isModalOpen}
          onConfirm={confirmDelete}
          onCancel={cancelDelete}
          message={`Deseja realmente excluir o registro?`} 
        />
      </>
    );
  };
  
  export default ContatoCRMViewGrid;