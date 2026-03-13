import { useState, useEffect, useCallback, useMemo } from 'react';
import { GroupDescriptor, process } from '@progress/kendo-data-query';

interface UseGridGroupingProps {
  data: any[];
  defaultGroupBy?: string | string[];
  initialGroupDescriptors?: GroupDescriptor[];
  defaultSortDirection?: 'asc' | 'desc';
}

interface UseGridGroupingReturn {
  groupedData: any[];
  group: GroupDescriptor[];
  handleGroupChange: (event: { group: GroupDescriptor[] }) => void;  
  resetGrouping: () => void;
  addGroupBy: (field: string) => void;
  removeGroupBy: (field: string) => void;
}

export const useGridGrouping = ({
  data,
  defaultGroupBy,
  initialGroupDescriptors = [],
  defaultSortDirection = 'asc'
}: UseGridGroupingProps): UseGridGroupingReturn => {
  
  // Estado para os descritores de agrupamento
  const [group, setGroup] = useState<GroupDescriptor[]>(() => {
    if (initialGroupDescriptors.length > 0) {
      return initialGroupDescriptors;
    }
    
    if (defaultGroupBy) {
      const fieldsToGroup = Array.isArray(defaultGroupBy) ? defaultGroupBy : [defaultGroupBy];
      return fieldsToGroup.map(field => ({ 
        field, 
        dir: defaultSortDirection 
      }));
    }
    
    return [];
  });

  // Processa os dados com agrupamento
  const groupedData = useMemo(() => {
    if (group.length === 0) {
      return data;
    }

    const processedResult = process(data, {
      group: group
    });

    return processedResult.data;
  }, [data, group]);

  // Handler para mudanças no agrupamento
  const handleGroupChange = useCallback((event: { group: GroupDescriptor[] }) => {
    setGroup(event.group);
  }, []);

  // Função para resetar agrupamento
  const resetGrouping = useCallback(() => {
    setGroup([]);
  }, []);

  // Função para adicionar um campo ao agrupamento
  const addGroupBy = useCallback((field: string, sortDirection: 'asc' | 'desc' = defaultSortDirection) => {
    setGroup(prev => {
      const exists = prev.some(g => g.field === field);
      if (exists) return prev;
      
      return [...prev, { field, dir: sortDirection }];
    });
  }, [defaultSortDirection]);

  // Função para remover um campo do agrupamento
  const removeGroupBy = useCallback((field: string) => {
    setGroup(prev => prev.filter(g => g.field !== field));
  }, []);

  return {
    groupedData,
    group,
    handleGroupChange,
    resetGrouping,
    addGroupBy,
    removeGroupBy
  };
};

// Hook auxiliar para facilitar o uso comum
export const useDefaultGrouping = (
  data: any[], 
  field: string, 
  sortDirection: 'asc' | 'desc' = 'asc'
) => {
  return useGridGrouping({
    data,
    defaultGroupBy: field,
    defaultSortDirection: sortDirection
  });
};