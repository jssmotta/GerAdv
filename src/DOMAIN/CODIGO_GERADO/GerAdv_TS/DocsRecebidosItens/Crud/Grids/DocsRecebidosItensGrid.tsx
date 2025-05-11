//CrudGrid.tsx.txt
"use client";
import { AppGridToolbar } from "@/app/components/Cruds/GridToolbar";
import { useIsMobile } from "@/app/context/MobileContext";
import { useSystemContext } from "@/app/context/SystemContext";
import { DocsRecebidosItensEmpty } from "../../../Models/DocsRecebidosItens";
import { useWindow } from "@/app/hooks/useWindows";
import { useRouter } from "next/navigation";
import { useEffect, useMemo, useState } from "react";
import { IDocsRecebidosItens } from "../../Interfaces/interface.DocsRecebidosItens";
import { DocsRecebidosItensService } from "../../Services/DocsRecebidosItens.service";
import { DocsRecebidosItensApi } from "../../Apis/ApiDocsRecebidosItens";
import { DocsRecebidosItensGridMobileComponent } from "../GridsMobile/DocsRecebidosItens";
import { DocsRecebidosItensGridDesktopComponent } from "../GridsDesktop/DocsRecebidosItens";
import { getParamFromUrl } from "@/app/tools/helpers";
import { FilterDocsRecebidosItens } from "../../Filters/DocsRecebidosItens";
import { ConfirmationModal } from "@/app/components/Cruds/ConfirmationModal";
import DocsRecebidosItensWindow from "./DocsRecebidosItensWindow";

const DocsRecebidosItensGrid: React.FC = () => {
    const { systemContext } = useSystemContext();
    const [selectedId, setSelectedId] = useState<number | null>(null);
    const isMobile = useIsMobile();
    const router = useRouter();
    const dimensions = useWindow();
    
    const [docsrecebidositens, setDocsRecebidosItens] = useState<IDocsRecebidosItens[]>([]);
    const [showInc, setShowInc] = useState(false);
    const [selectedDocsRecebidosItens, setSelectedDocsRecebidosItens] = useState<IDocsRecebidosItens>(DocsRecebidosItensEmpty());     

    const [isModalOpen, setIsModalOpen] = useState(false);
    const [deleteId, setDeleteId] = useState<number | null>(null);
    const dadoApi = new DocsRecebidosItensApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');

    const [currFilter, setCurrFilter] = useState<FilterDocsRecebidosItens | undefined | null>(null);

    const docsrecebidositensService = useMemo(() => {
      return new DocsRecebidosItensService(
          new DocsRecebidosItensApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
      ); 
    }, [systemContext?.Uri, systemContext?.Token]);
  
    const fetchDocsRecebidosItens = async (filtro?: FilterDocsRecebidosItens | undefined | null) => {
      setCurrFilter(filtro);
      if (isMobile) {
        const data = await docsrecebidositensService.getList(filtro ?? {} as FilterDocsRecebidosItens);
        setDocsRecebidosItens(data);
      }
      else {
        const data = await docsrecebidositensService.getAll(filtro ?? {} as FilterDocsRecebidosItens);
        setDocsRecebidosItens(data);
      }
    };
  
    useEffect(() => { //  Ref: FILTER_FETCH
      fetchDocsRecebidosItens(currFilter);
    }, [showInc]);
  
    const handleRowClick = (docsrecebidositens: IDocsRecebidosItens) => {
      if (isMobile) {
        router.push(`/pages/docsrecebidositens/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${docsrecebidositens.id}`);
      } else {
        setSelectedDocsRecebidosItens(docsrecebidositens);
        setShowInc(true);
      }
    };
  
    const handleAdd = () => {
      if (isMobile) {
        router.push(`/pages/docsrecebidositens/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=0`);
        return;
      }
      setSelectedDocsRecebidosItens(DocsRecebidosItensEmpty());
      setShowInc(true);
    };
  
    const handleClose = () => {
      setShowInc(false);
    };
  
    const handleSuccess = () => {
      fetchDocsRecebidosItens(currFilter);
      setShowInc(false);
    };

    const handleError = () => {
      setShowInc(false);
    };
  
    const onDeleteClick = (e: any) => {
        const docsrecebidositens = e.dataItem;		
        setDeleteId(docsrecebidositens.id);
        setIsModalOpen(true);
    };
      
    const confirmDelete = async () => {
        if (deleteId !== null) {
            try {
                await dadoApi.delete(deleteId);			
                fetchDocsRecebidosItens(currFilter);
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
           <DocsRecebidosItensGridMobileComponent data={docsrecebidositens} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} setSelectedId={setSelectedId}  /> :
           <DocsRecebidosItensGridDesktopComponent data={docsrecebidositens} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} setSelectedId={setSelectedId}  /> }       
     
        <DocsRecebidosItensWindow
          isOpen={showInc}
          onClose={handleClose}
          dimensions={dimensions} 
          onSuccess={handleSuccess}
          onError={handleError}
          selectedDocsRecebidosItens={selectedDocsRecebidosItens}>       
        </DocsRecebidosItensWindow>

        <ConfirmationModal 
          isOpen={isModalOpen}
          onConfirm={confirmDelete}
          onCancel={cancelDelete}
          message={`Deseja realmente excluir o registro?`} 
        />
      </>
    );
  };
  
  export default DocsRecebidosItensGrid;