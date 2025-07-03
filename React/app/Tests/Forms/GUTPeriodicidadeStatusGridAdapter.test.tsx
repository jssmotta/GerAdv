// GUTPeriodicidadeStatusGridAdapter.test.tsx
import React from 'react';
import { render } from '@testing-library/react';
import { GUTPeriodicidadeStatusGridAdapter } from '@/app/GerAdv_TS/GUTPeriodicidadeStatus/Adapter/GUTPeriodicidadeStatusGridAdapter';
// Mock GUTPeriodicidadeStatusGrid component
jest.mock('@/app/GerAdv_TS/GUTPeriodicidadeStatus/Crud/Grids/GUTPeriodicidadeStatusGrid', () => () => <div data-testid='gutperiodicidadestatus-grid-mock' />);
describe('GUTPeriodicidadeStatusGridAdapter', () => {
  it('should render GUTPeriodicidadeStatusGrid component', () => {
    const adapter = new GUTPeriodicidadeStatusGridAdapter();
    const { getByTestId } = render(<>{adapter.render()}</>);
    expect(getByTestId('gutperiodicidadestatus-grid-mock')).toBeInTheDocument();
  });
});