// WindowId.tsx.txt
import React, { useEffect, useMemo } from "react";
import { useSystemContext } from "@/app/context/SystemContext";
import { ITipoProDesposito } from "../../Interfaces/interface.TipoProDesposito";
import { TipoProDespositoService } from "../../Services/TipoProDesposito.service";
import { TipoProDespositoApi } from "../../Apis/ApiTipoProDesposito";
import TipoProDespositoWindow from "./TipoProDespositoWindow";

interface TipoProDespositoWindowIdProps {
    isOpen: boolean; 
    onClose: () => void;    
    id?: number;
    onSuccess: () => void;
    onError: () => void;
}

const TipoProDespositoWindowId: React.FC<TipoProDespositoWindowIdProps> = ({
    isOpen,
    onClose,    
    id,
    onSuccess,
    onError,
}) => {

    const { systemContext } = useSystemContext(); 
    const tipoprodespositoService = useMemo(() => {
        return new TipoProDespositoService(
            new TipoProDespositoApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
        );
    }, [systemContext?.Uri, systemContext?.Token]);

    const [data, setData] = React.useState<ITipoProDesposito | null>(null);

    useEffect(() => {
        const fetchData = async () => {
            if (id) {
                 const response = await tipoprodespositoService.fetchTipoProDespositoById(id??0);
                setData(response);
            }
        };
        fetchData();
    }, [isOpen, id]);
     
    return (
        <>
            {data && isOpen && (
                <TipoProDespositoWindow 
                    isOpen={isOpen}
                    onClose={onClose}                    
                    selectedTipoProDesposito={data} 
                    onSuccess={onSuccess} 
                    onError={onError} />
            )}
        </>
    );
};

export default TipoProDespositoWindowId;