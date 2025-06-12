// WindowId.tsx.txt
import React, { useEffect, useMemo } from 'react';
import { useSystemContext } from '@/app/context/SystemContext';
import { IGraph } from '../../Interfaces/interface.Graph';
import { GraphService } from '../../Services/Graph.service';
import { GraphApi } from '../../Apis/ApiGraph';
import GraphWindow from './GraphWindow';
import {GraphEmpty } from '@/app/GerAdv_TS/Models/Graph';
interface GraphWindowIdProps {
  isOpen: boolean;
  onClose: () => void;
  id?: number;
  onSuccess: (registro?: any) => void;
  onError: () => void;
}
const GraphWindowId: React.FC<GraphWindowIdProps> = ({
  isOpen, 
  onClose, 
  id, 
  onSuccess, 
  onError, 
}) => {
const { systemContext } = useSystemContext();
const graphService = useMemo(() => {
  return new GraphService(
  new GraphApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
);
}, [systemContext?.Uri, systemContext?.Token]);
const [data, setData] = React.useState<IGraph | null>(null);
useEffect(() => {
  const fetchData = async () => {
    if (id !== null && id === 0) {
      setData(GraphEmpty() as IGraph);
      return;
    }
    if (id) {
      const response = await graphService.fetchGraphById(id??0);
      setData(response);
    }
  };
  fetchData();
}, [isOpen]);

return (
<>
{data && isOpen && (
  <GraphWindow
  isOpen={isOpen}
  onClose={onClose}
  selectedGraph={data}
  onSuccess={onSuccess}
  onError={onError} />
  )}
</>
);
};
export default GraphWindowId;