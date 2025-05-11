// WindowId.tsx.txt
import React, { useEffect, useMemo } from "react";
import { useSystemContext } from "@/app/context/SystemContext";
import { ITipoEndereco } from "../../Interfaces/interface.TipoEndereco";
import { TipoEnderecoService } from "../../Services/TipoEndereco.service";
import { TipoEnderecoApi } from "../../Apis/ApiTipoEndereco";
import TipoEnderecoWindow from "./TipoEnderecoWindow";

interface TipoEnderecoWindowIdProps {
    isOpen: boolean; 
    onClose: () => void;    
    id?: number;
    onSuccess: () => void;
    onError: () => void;
}

const TipoEnderecoWindowId: React.FC<TipoEnderecoWindowIdProps> = ({
    isOpen,
    onClose,    
    id,
    onSuccess,
    onError,
}) => {

    const { systemContext } = useSystemContext(); 
    const tipoenderecoService = useMemo(() => {
        return new TipoEnderecoService(
            new TipoEnderecoApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
        );
    }, [systemContext?.Uri, systemContext?.Token]);

    const [data, setData] = React.useState<ITipoEndereco | null>(null);

    useEffect(() => {
        const fetchData = async () => {
            if (id) {
                 const response = await tipoenderecoService.fetchTipoEnderecoById(id??0);
                setData(response);
            }
        };
        fetchData();
    }, [isOpen, id]);
     
    return (
        <>
            {data && isOpen && (
                <TipoEnderecoWindow 
                    isOpen={isOpen}
                    onClose={onClose}                    
                    selectedTipoEndereco={data} 
                    onSuccess={onSuccess} 
                    onError={onError} />
            )}
        </>
    );
};

export default TipoEnderecoWindowId;