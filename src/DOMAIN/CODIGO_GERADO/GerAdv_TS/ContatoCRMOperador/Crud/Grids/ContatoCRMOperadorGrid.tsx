//CrudGrid.tsx.txt
"use client";
import { AppGridToolbar } from "@/app/components/Cruds/GridToolbar";
import { useIsMobile } from "@/app/context/MobileContext";
import { useSystemContext } from "@/app/context/SystemContext";
import { ContatoCRMOperadorEmpty } from "../../../Models/ContatoCRMOperador";
import { useWindow } from "@/app/hooks/useWindows";
import { useRouter } from "next/navigation";
import { useEffect, useMemo, useState } from "react";
import { IContatoCRMOperador } from "../../Interfaces/interface.ContatoCRMOperador";
import { ContatoCRMOperadorService } from "../../Services/ContatoCRMOperador.service";
import { ContatoCRMOperadorApi } from "../../Apis/ApiContatoCRMOperador";
import { ContatoCRMOperadorGridMobileComponent } from "../GridsMobile/ContatoCRMOperador";
import { ContatoCRMOperadorGridDesktopComponent } from "../GridsDesktop/ContatoCRMOperador";
import { getParamFromUrl } from "@/app/tools/helpers";
import { FilterContatoCRMOperador } from "../../Filters/ContatoCRMOperador";
import { ConfirmationModal } from "@/app/components/Cruds/ConfirmationModal";
import ContatoCRMOperadorWindow from "./ContatoCRMOperadorWindow";

const ContatoCRMOperadorGrid: React.FC = () => {
    const { systemContext } = useSystemContext();
    const [selectedId, setSelectedId] = useState<number | null>(null);
    const isMobile = useIsMobile();
    const router = useRouter();
    const dimensions = useWindow();
    
    const [contatocrmoperador, setContatoCRMOperador] = useState<IContatoCRMOperador[]>([]);
    const [showInc, setShowInc] = useState(false);
    const [selectedContatoCRMOperador, setSelectedContatoCRMOperador] = useState<IContatoCRMOperador>(ContatoCRMOperadorEmpty());     

    const [isModalOpen, setIsModalOpen] = useState(false);
    const [deleteId, setDeleteId] = useState<number | null>(null);
    const dadoApi = new ContatoCRMOperadorApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');

    const [currFilter, setCurrFilter] = useState<FilterContatoCRMOperador | undefined | null>(null);

    const contatocrmoperadorService = useMemo(() => {
      return new ContatoCRMOperadorService(
          new ContatoCRMOperadorApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
      ); 
    }, [systemContext?.Uri, systemContext?.Token]);
  
    const fetchContatoCRMOperador = async (filtro?: FilterContatoCRMOperador | undefined | null) => {
      setCurrFilter(filtro);
      if (isMobile) {
        const data = await contatocrmoperadorService.getAll(filtro ?? {} as FilterContatoCRMOperador);
        setContatoCRMOperador(data);
      }
      else {
        const data = await contatocrmoperadorService.getAll(filtro ?? {} as FilterContatoCRMOperador);
        setContatoCRMOperador(data);
      }
    };
  
    useEffect(() => { //  Ref: FILTER_FETCH
      fetchContatoCRMOperador(currFilter);
    }, [showInc]);
  
    const handleRowClick = (contatocrmoperador: IContatoCRMOperador) => {
      if (isMobile) {
        router.push(`/pages/contatocrmoperador/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${contatocrmoperador.id}`);
      } else {
        setSelectedContatoCRMOperador(contatocrmoperador);
        setShowInc(true);
      }
    };
  
    const handleAdd = () => {
      if (isMobile) {
        router.push(`/pages/contatocrmoperador/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=0`);
        return;
      }
      setSelectedContatoCRMOperador(ContatoCRMOperadorEmpty());
      setShowInc(true);
    };
  
    const handleClose = () => {
      setShowInc(false);
    };
  
    const handleSuccess = () => {
      fetchContatoCRMOperador(currFilter);
      setShowInc(false);
    };

    const handleError = () => {
      setShowInc(false);
    };
  
    const onDeleteClick = (e: any) => {
        const contatocrmoperador = e.dataItem;		
        setDeleteId(contatocrmoperador.id);
        setIsModalOpen(true);
    };
      
    const confirmDelete = async () => {
        if (deleteId !== null) {
            try {
                await dadoApi.delete(deleteId);			
                fetchContatoCRMOperador(currFilter);
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
           <ContatoCRMOperadorGridMobileComponent data={contatocrmoperador} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} setSelectedId={setSelectedId}  /> :
           <ContatoCRMOperadorGridDesktopComponent data={contatocrmoperador} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} setSelectedId={setSelectedId}  /> }       
     
        <ContatoCRMOperadorWindow
          isOpen={showInc}
          onClose={handleClose}
          dimensions={dimensions} 
          onSuccess={handleSuccess}
          onError={handleError}
          selectedContatoCRMOperador={selectedContatoCRMOperador}>       
        </ContatoCRMOperadorWindow>

        <ConfirmationModal 
          isOpen={isModalOpen}
          onConfirm={confirmDelete}
          onCancel={cancelDelete}
          message={`Deseja realmente excluir o registro?`} 
        />
      </>
    );
  };
  
  export default ContatoCRMOperadorGrid;