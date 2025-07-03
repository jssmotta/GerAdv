// GUTPeriodicidadeGridAdapter.test.tsx
import React from 'react';
import { render } from '@testing-library/react';
import { GUTPeriodicidadeGridAdapter } from '@/app/GerAdv_TS/GUTPeriodicidade/Adapter/GUTPeriodicidadeGridAdapter';
// Mock GUTPeriodicidadeGrid component
jest.mock('@/app/GerAdv_TS/GUTPeriodicidade/Crud/Grids/GUTPeriodicidadeGrid', () => () => <div data-testid='gutperiodicidade-grid-mock' />);
describe('GUTPeriodicidadeGridAdapter', () => {
  it('should render GUTPeriodicidadeGrid component', () => {
    const adapter = new GUTPeriodicidadeGridAdapter();
    const { getByTestId } = render(<>{adapter.render()}</>);
    expect(getByTestId('gutperiodicidade-grid-mock')).toBeInTheDocument();
  });
});