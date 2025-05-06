//CrudGrid.tsx.txt
"use client";
import { AppGridToolbar } from "@/app/components/Cruds/GridToolbar";
import { useIsMobile } from "@/app/context/MobileContext";
import { useSystemContext } from "@/app/context/SystemContext";
import { TipoEnderecoEmpty } from "../../../Models/TipoEndereco";
import { useWindow } from "@/app/hooks/useWindows";
import { useRouter } from "next/navigation";
import { useEffect, useMemo, useState } from "react";
import { ITipoEndereco } from "../../Interfaces/interface.TipoEndereco";
import { TipoEnderecoService } from "../../Services/TipoEndereco.service";
import { TipoEnderecoApi } from "../../Apis/ApiTipoEndereco";
import { TipoEnderecoGridMobileComponent } from "../GridsMobile/TipoEndereco";
import { TipoEnderecoGridDesktopComponent } from "../GridsDesktop/TipoEndereco";
import { getParamFromUrl } from "@/app/tools/helpers";
import { FilterTipoEndereco } from "../../Filters/TipoEndereco";
import { ConfirmationModal } from "@/app/components/Cruds/ConfirmationModal";
import TipoEnderecoWindow from "./TipoEnderecoWindow";

const TipoEnderecoGrid: React.FC = () => {
    const { systemContext } = useSystemContext();
    const [selectedId, setSelectedId] = useState<number | null>(null);
    const isMobile = useIsMobile();
    const router = useRouter();
    const dimensions = useWindow();
    
    const [tipoendereco, setTipoEndereco] = useState<ITipoEndereco[]>([]);
    const [showInc, setShowInc] = useState(false);
    const [selectedTipoEndereco, setSelectedTipoEndereco] = useState<ITipoEndereco>(TipoEnderecoEmpty());     

    const [isModalOpen, setIsModalOpen] = useState(false);
    const [deleteId, setDeleteId] = useState<number | null>(null);
    const dadoApi = new TipoEnderecoApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');

    const [currFilter, setCurrFilter] = useState<FilterTipoEndereco | undefined | null>(null);

    const tipoenderecoService = useMemo(() => {
      return new TipoEnderecoService(
          new TipoEnderecoApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
      ); 
    }, [systemContext?.Uri, systemContext?.Token]);
  
    const fetchTipoEndereco = async (filtro?: FilterTipoEndereco | undefined | null) => {
      setCurrFilter(filtro);
      if (isMobile) {
        const data = await tipoenderecoService.getList(filtro ?? {} as FilterTipoEndereco);
        setTipoEndereco(data);
      }
      else {
        const data = await tipoenderecoService.getAll(filtro ?? {} as FilterTipoEndereco);
        setTipoEndereco(data);
      }
    };
  
    useEffect(() => { //  Ref: FILTER_FETCH
      fetchTipoEndereco(currFilter);
    }, [showInc]);
  
    const handleRowClick = (tipoendereco: ITipoEndereco) => {
      if (isMobile) {
        router.push(`/pages/tipoendereco/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${tipoendereco.id}`);
      } else {
        setSelectedTipoEndereco(tipoendereco);
        setShowInc(true);
      }
    };
  
    const handleAdd = () => {
      if (isMobile) {
        router.push(`/pages/tipoendereco/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=0`);
        return;
      }
      setSelectedTipoEndereco(TipoEnderecoEmpty());
      setShowInc(true);
    };
  
    const handleClose = () => {
      setShowInc(false);
    };
  
    const handleSuccess = () => {
      fetchTipoEndereco(currFilter);
      setShowInc(false);
    };

    const handleError = () => {
      setShowInc(false);
    };
  
    const onDeleteClick = (e: any) => {
        const tipoendereco = e.dataItem;		
        setDeleteId(tipoendereco.id);
        setIsModalOpen(true);
    };
      
    const confirmDelete = async () => {
        if (deleteId !== null) {
            try {
                await dadoApi.delete(deleteId);			
                fetchTipoEndereco(currFilter);
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
           <TipoEnderecoGridMobileComponent data={tipoendereco} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} setSelectedId={setSelectedId}  /> :
           <TipoEnderecoGridDesktopComponent data={tipoendereco} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} setSelectedId={setSelectedId}  /> }       
     
        <TipoEnderecoWindow
          isOpen={showInc}
          onClose={handleClose}
          dimensions={dimensions} 
          onSuccess={handleSuccess}
          onError={handleError}
          selectedTipoEndereco={selectedTipoEndereco}>       
        </TipoEnderecoWindow>

        <ConfirmationModal 
          isOpen={isModalOpen}
          onConfirm={confirmDelete}
          onCancel={cancelDelete}
          message={`Deseja realmente excluir o registro?`} 
        />
      </>
    );
  };
  
  export default TipoEnderecoGrid;